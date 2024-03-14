using UnityEngine;

/// <summary>
/// This class is used to make the door open when the button is pressed.
/// </summary>
public class DoorButton : Button
{
    [SerializeField] private DoorSwitcher _doorSwitcher;

    // When the player enters the button collider the OnPressed method is called
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.GetComponent<ChildMovement>() != null && _isPressed == false)
        {
            _isPressed = true;
            OnPressed();
        }
    }

    // The OnPressed method is overriden to call the SetDoorState method from the DoorSwitcher class
    protected override void OnPressed()
    {
        ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer);
        buttonPressCommand.Execute();
        _doorSwitcher.SetDoorState(true);
    }
}
