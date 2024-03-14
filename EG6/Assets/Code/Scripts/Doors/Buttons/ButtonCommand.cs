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
    private SpriteRenderer _buttonRenderer; // Renderer reference to change the color of the button
    private Sprite _previousSprite; // Store the previous sprite of the button

    // Constructor
    public ButtonPressCommand(int buttonId, SpriteRenderer buttonRenderer)
    {
        _buttonId = buttonId;
        _buttonRenderer = buttonRenderer;
    }

    // Execute the command, change the color of the button to green
    public void Execute()
    {
        _previousSprite = _buttonRenderer.sprite;
        Sprite sprite = Resources.Load<Sprite>("Sprites/Environment/SpritesFinales/ButtonPressed");
        _buttonRenderer.sprite = sprite;
    }

    // This method is called to undo the action
    public void Undo()
    {
        _buttonRenderer.sprite = _previousSprite;
        Button button = _buttonRenderer.GetComponent<Button>();
        button.IsPressed = false;
    }

    // public method to get the button id
    public int GetButtonId()
    {
        return _buttonId;
    }
}
