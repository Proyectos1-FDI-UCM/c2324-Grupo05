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
    private SpriteRenderer _buttonRenderer; 
    private Sprite _previousSprite; 


    public ButtonPressCommand(int buttonId, SpriteRenderer buttonRenderer)
    {
        _buttonId = buttonId;
        _buttonRenderer = buttonRenderer;
    }


    public void Execute()
    {
        _previousSprite = _buttonRenderer.sprite;
        Sprite sprite = Resources.Load<Sprite>("Sprites/Environment/SpritesFinales/ButtonPressed");
        _buttonRenderer.sprite = sprite;
    }


    public void Undo()
    {
        AudioClip onPressedSound = Resources.Load<AudioClip>("Audio/Buttons/buttonReleased");
        AudioSource.PlayClipAtPoint(onPressedSound, _buttonRenderer.transform.position);
        _buttonRenderer.sprite = _previousSprite;
        Button button = _buttonRenderer.GetComponent<Button>();
        button.IsPressed = false;
    }

    
    public int GetButtonId()
    {
        return _buttonId;
    }
}
