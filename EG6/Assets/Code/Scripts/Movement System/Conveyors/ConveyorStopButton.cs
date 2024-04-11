using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// This class is used to stop the conveyor belt.
/// </summary>
public class ConveyorStopButton : Button
{
    [SerializeField] private ConveyorBelt _conveyorBelt;
    private BoxCollider2D _collider;


    protected override void Start()
    {
        base.Start();
        _collider = _conveyorBelt.GetComponent<BoxCollider2D>();
    }


    protected override async void ButtonPressed()
    {
        base.ButtonPressed();
        ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer, _localObjectHandler);
        buttonPressCommand.Execute();

        if (_collider.enabled == true)
        {
            _collider.enabled = false;
        }
        else
        {
            _collider.enabled = true;
        }

        await Task.Delay(100);
        buttonPressCommand.Undo();
    }
}
