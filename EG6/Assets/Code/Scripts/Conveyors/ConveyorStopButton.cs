using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// This class is used to make the conveyor belt change its direction when the button is pressed.
/// It can change the direction of the conveyor belt only if the object that pressed the button is a child.
/// </summary>
public class ConveyorStopButton : Button
{
    [SerializeField] private ConveyorBelt _conveyorBelt;
    ConveyorBeltAnimator anim;

    protected override async void OnPressed()
    {
        ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer);
        buttonPressCommand.Execute();
        //anim = GameObject.FindGameObjectWithTag("A").GetComponent<ConveyorBeltAnimator>();
        //anim.RotateSprite();

        if (_conveyorBelt.MovementDirection == Vector2.zero)
        {
            _conveyorBelt.MovementDirection = new Vector2(1, 0);
            Debug.Log("Conveyor belt is moving");
        }
        else
        {
            _conveyorBelt.MovementDirection = Vector2.zero;
            Debug.Log("Conveyor belt is stopped");
        }

        //_conveyorBelt.MovementDirection = _conveyorBelt.MovementDirection * -1;
        await Task.Delay(100);
        buttonPressCommand.Undo();

    }

}
