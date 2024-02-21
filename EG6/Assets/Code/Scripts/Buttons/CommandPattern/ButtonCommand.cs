using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressCommand : ICommand
{
    private int _buttonId;
    private Renderer _buttonRenderer; // Renderer reference to change the color of the button
    private Color _previousColor; // Store the previous color of the button to undo the command

    // Constructor
    public ButtonPressCommand(int buttonId, Renderer buttonRenderer)
    {
        _buttonId = buttonId;
        _buttonRenderer = buttonRenderer;
    }

    // Execute the command, change the color of the button to green
    public void Execute()
    {
        Debug.Log("Button with id " + _buttonId + " was pressed");
        _previousColor = _buttonRenderer.material.color;
        _buttonRenderer.material.color = Color.green;
    }

    // Undo the command, change the color of the button to the previous color
    public void Undo()
    {
        _buttonRenderer.material.color = _previousColor;
    }

    // public method to get the button id
    public int GetButtonId()
    {
        return _buttonId;
    }
}
