using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ConveyorButton : Button
{
    [SerializeField] private ConveyorBelt _conveyorBelt;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.GetComponent<ChildMovement>() != null)
        {
            OnPressed();
        }    
    }

    protected override async void OnPressed()
    {
        ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer);
        buttonPressCommand.Execute();
        _conveyorBelt.MovementDirection = _conveyorBelt.MovementDirection * -1;
        await Task.Delay(1000);
        buttonPressCommand.Undo();
        
    }
    
}
