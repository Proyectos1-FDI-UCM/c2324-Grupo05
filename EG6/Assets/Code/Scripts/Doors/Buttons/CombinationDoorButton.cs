using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to make the door open when the correct sequence of buttons is pressed.
/// </summary>
public class CombinationDoorButton : Button
{
    [SerializeField] private DoorSwitcher _doorSwitcher;
    [SerializeField] private SequenceChecker _sequenceChecker;
    [SerializeField] private Animator _animator;

    // When the player enters the button collider the OnPressed method is called
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.GetComponent<ChildMovement>() != null)
        {
            OnPressed();
        }
    }

    // The OnPressed method is overriden to check the sequence of buttons pressed and open the door
    protected override void OnPressed()
    {
        {
            ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer, _animator);
            buttonPressCommand.Execute();
            _sequenceChecker.AddButtonToSequence(buttonPressCommand);
            _sequenceChecker.CheckSequence();
        }
    }
    
}
