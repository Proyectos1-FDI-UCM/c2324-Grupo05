using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// This class is used to make the conveyor belt change its direction when the button is pressed.
/// It can change the direction of the conveyor belt only if the object that pressed the button is a child.
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
        _anim.RotateSprite();
        _conveyorBelt.MovementDirection = _conveyorBelt.MovementDirection * -1;
        await Task.Delay(1000);
        buttonPressCommand.Undo();
    }
}
