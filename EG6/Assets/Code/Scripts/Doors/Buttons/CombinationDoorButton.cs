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
