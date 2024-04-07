using UnityEngine;

/// <summary>
/// This class is used to make the door open when the button is pressed.
/// </summary>
public class DoorButton : Button
{
    [SerializeField] private DoorSwitcher _doorSwitcher;

    // The OnPressed method is overriden to call the SetDoorState method from the DoorSwitcher class
    protected override void ButtonPressed()
    {
        base.ButtonPressed();
        ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer);
        buttonPressCommand.Execute();
        _doorSwitcher.SetDoorState(true);
    }
}
