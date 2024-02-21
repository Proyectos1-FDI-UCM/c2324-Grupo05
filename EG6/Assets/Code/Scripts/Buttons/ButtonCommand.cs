using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Command
{
    public virtual void Execute()
    {
        
    }

    public virtual void Undo()
    {
        
    }
}

public class ButtonPressCommand : Command
{
    private int _buttonId;
    private Renderer _buttonRenderer;
    private Color _previousColor;

    public ButtonPressCommand(int buttonId, Renderer buttonRenderer)
    {
        _buttonId = buttonId;
        _buttonRenderer = buttonRenderer;
    }

    public override void Execute()
    {
        Debug.Log("Button with id " + _buttonId + " was pressed");
        _previousColor = _buttonRenderer.material.color;
        _buttonRenderer.material.color = Color.green;
    }

    public override void Undo()
    {
        _buttonRenderer.material.color = _previousColor;
    }

    public int GetButtonId()
    {
        return _buttonId;
    }
}
