using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationDoorButton : Button
{
    [SerializeField] private DoorSwitcher _doorSwitcher;
    [SerializeField] private SequenceChecker _sequenceChecker;

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
            ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer);
            buttonPressCommand.Execute();
            _sequenceChecker.AddButtonToSequence(buttonPressCommand);
            _sequenceChecker.CheckSequence();
        }
    }
    
}
