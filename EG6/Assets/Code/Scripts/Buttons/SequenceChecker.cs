using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SequenceChecker : MonoBehaviour
{
    [SerializeField] private List<int> _combination;
    private List<ButtonPressCommand> _sequence = new List<ButtonPressCommand>();
    private List<ButtonPressCommand> _desiredSequence = new List<ButtonPressCommand>();
    private bool _isSequenceMatched = true;

    [SerializeField] private DoorSwitcher _door;

    
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
        if (_sequence.Count == _desiredSequence.Count)
        {
            _isSequenceMatched = true;
            for (int i = 0; i < _sequence.Count; i++)
            {
                if (_sequence[i].GetButtonId() != _desiredSequence[i].GetButtonId())
                {
                    _isSequenceMatched = false;
                    break;
                }
            }

            if (_isSequenceMatched)
            {
                _door.SetDoorState(true);
                UndoSequence();
            }
            else
            {
                UndoSequence();
            }
            _sequence.Clear();
        }
    }

    private void UndoSequence()
    {
        for (int i = _sequence.Count - 1; i >= 0; i--)
        {
            _sequence[i].Undo();
        }
    }
}
