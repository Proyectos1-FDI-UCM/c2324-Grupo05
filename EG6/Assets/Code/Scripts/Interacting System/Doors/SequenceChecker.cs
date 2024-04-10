using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// This class is used to check if the player has pressed the correct sequence of buttons to open the door.
/// It uses the Command pattern to store the commands that the player has pressed and compare them with the desired sequence.
/// </summary>
public class SequenceChecker : MonoBehaviour
{
    [SerializeField] private List<int> _combination;
    [SerializeField] private DoorSwitcher _door; 

    private List<ButtonPressCommand> _sequence = new List<ButtonPressCommand>(); 
    private List<ButtonPressCommand> _desiredSequence = new List<ButtonPressCommand>();
    private bool _isSequenceMatched = true;
    

    private void Start()
    {
        SetCombination();
    }  


    private void SetCombination()
    {
        for (int i = 0; i < _combination.Count; i++)
        {
            _desiredSequence.Add(new ButtonPressCommand(_combination[i], null));
        }
    }



    public void AddButtonToSequence(ButtonPressCommand button)
    {
        _sequence.Add(button);
    }


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


    private async void UndoSequence()
    {
        List<ButtonPressCommand> sequenceCopy;

        lock (_sequence) // Lock, because it can be modified by the player while another async task is running
        {
            sequenceCopy = new List<ButtonPressCommand>(_sequence); 
            _sequence.Clear(); 
        }

        for (int i = sequenceCopy.Count - 1; i >= 0; i--)
        {
            await Task.Delay(300);
            sequenceCopy[i].Undo();
        }
    }
}
