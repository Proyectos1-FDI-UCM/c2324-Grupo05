using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// This class is used to make the conveyor belt change its direction when the button is pressed.
/// </summary>
public class ConveyorButton : Button
{
    [SerializeField] private ConveyorBelt _conveyorBelt;
    [SerializeField] private ConveyorBeltAnimator _anim;


    protected override async void ButtonPressed()
    {
        base.ButtonPressed();

        ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer);
        buttonPressCommand.Execute();

        _conveyorBelt.PushDirection = _conveyorBelt.PushDirection * -1;
        _anim.RotateSprite();

        await Task.Delay(1000);
        buttonPressCommand.Undo();
    }
}
