using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;
using System.Threading.Tasks;

/// <summary>
/// This class is used to check if the player has pressed the correct sequence of buttons to open the door.
/// It uses the Command pattern to store the commands that the player has pressed and compare them with the desired sequence.
/// </summary>
public class SequenceChecker : MonoBehaviour
{
    [SerializeField] private List<int> _combination; // List of the button ids that the player needs to press
    [SerializeField] private DoorSwitcher _door; // Reference to the door switcher
    private List<ButtonPressCommand> _sequence = new List<ButtonPressCommand>(); // Commands that the player has pressed
    private List<ButtonPressCommand> _desiredSequence = new List<ButtonPressCommand>(); // field to store the desired sequence
    private bool _isSequenceMatched = true;
    
    private void Start()
    {
        SetCombination();
    }  

    // Method to set the combination of the buttons by creating the desired sequence
    private void SetCombination()
    {
        for (int i = 0; i < _combination.Count; i++)
        {
            _desiredSequence.Add(new ButtonPressCommand(_combination[i], null));
        }
    }


    // Method to add the button-command to the current sequence
    public void AddButtonToSequence(ButtonPressCommand button)
    {
        _sequence.Add(button);
    }

    // Method to check if the sequence is matched and open the door if it's true
    public void CheckSequence()
    {   
        for (int i = 0; i < _sequence.Count; i++) 
        {
            if (_sequence[i].GetButtonId() != _desiredSequence[i].GetButtonId() && _isSequenceMatched == true)
            {
                _isSequenceMatched = false;
            }
        }

        if (_isSequenceMatched && _sequence.Count == _desiredSequence.Count)
        {
            _door.SetDoorState(true);
            return;
        }
        else if (!_isSequenceMatched || _sequence.Count >= _desiredSequence.Count)
        {
            UndoSequence();
            _isSequenceMatched = true;
        }

    }

    // Method to undo the sequence (undo all commands that the player has pressed)
    private async void UndoSequence()
    {
        List<ButtonPressCommand> sequenceCopy;

        lock (_sequence)
        {
            sequenceCopy = new List<ButtonPressCommand>(_sequence); // Создаем копию _sequence
            _sequence.Clear(); // Очищаем _sequence
        }

        for (int i = sequenceCopy.Count - 1; i >= 0; i--)
        {
            await Task.Delay(300);
            sequenceCopy[i].Undo();
        }
    }
}
