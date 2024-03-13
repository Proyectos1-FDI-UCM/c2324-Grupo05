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
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.GetComponent<ChildMovement>() != null)
        {
            OnPressed();
        }    
    }

    protected override async void OnPressed()
    {
        ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer, _animator);
        buttonPressCommand.Execute();
        _conveyorBelt.MovementDirection = _conveyorBelt.MovementDirection * -1;
        await Task.Delay(1000);
        buttonPressCommand.Undo();
        
    }
    
}
