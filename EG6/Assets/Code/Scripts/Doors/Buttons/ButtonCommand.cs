using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is used to store the command of the button press, execute it and undo it.
/// </summary>
public class ButtonPressCommand : ICommand
{
    private int _buttonId;
    private Renderer _buttonRenderer; // Renderer reference to change the color of the button
    private Color _previousColor; // Store the previous color of the button to undo the command
    private Animator _animator; // Reference to the Animator component

    // Constructor
    public ButtonPressCommand(int buttonId, Renderer buttonRenderer, Animator animator)
    {
        _buttonId = buttonId;
        _buttonRenderer = buttonRenderer;
        _animator = animator;
    }

    // Execute the command, change the color of the button to green
    public void Execute()
    {
        Debug.Log("Button with id " + _buttonId + " was pressed");
        _previousColor = _buttonRenderer.material.color;
        //_buttonRenderer.material.color = Color.green;
        //_animator.SetTrigger("Pressed");
    }

    // This method is called to undo the action
    public void Undo()
    {
        _buttonRenderer.material.color = _previousColor;
       // _animator.ResetTrigger("Pressed");
    }

    // public method to get the button id
    public int GetButtonId()
    {
        return _buttonId;
    }
}
