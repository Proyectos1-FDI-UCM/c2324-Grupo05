using UnityEngine;

/// <summary>
/// This class is used to store the command of the button press, execute it and undo it.
/// </summary>
public class ButtonPressCommand : ICommand
{
    private int _buttonId;
    private SpriteRenderer _buttonRenderer; 
    private Sprite _previousSprite; 
    private LocalObjectHandler _localObjectHandler;
    private AudioManager _audioManager;

    public ButtonPressCommand(int buttonId, SpriteRenderer buttonRenderer, LocalObjectHandler localObjectHandler)
    {
        _buttonId = buttonId;
        _buttonRenderer = buttonRenderer;
        _localObjectHandler = localObjectHandler;
    }


    public void Execute()
    {
        _previousSprite = _buttonRenderer.sprite;
        _audioManager.PlaySFX(_audioManager._buttonPressed);

        /*
        AudioClip onPressedSound = Resources.Load<AudioClip>("Audio/Buttons/buttonPressed");
        AudioSource.PlayClipAtPoint(onPressedSound, _buttonRenderer.transform.position);
        */
        
        Sprite sprite = Resources.Load<Sprite>("Sprites/Environment/SpritesFinales/ButtonPressed");
        _buttonRenderer.sprite = sprite;
        _localObjectHandler.PressedButtonsIDs.Add(_buttonId);
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public void Undo()
    {
        _audioManager.PlaySFX(_audioManager._buttonReleased);
        /*
        AudioClip onPressedSound = Resources.Load<AudioClip>("Audio/Buttons/buttonReleased");
        AudioSource.PlayClipAtPoint(onPressedSound, _buttonRenderer.transform.position);
        */
        _buttonRenderer.sprite = _previousSprite;
        Button button = _buttonRenderer.GetComponent<Button>();
        button.IsPressed = false;
        _localObjectHandler.PressedButtonsIDs.Remove(_buttonId);
    }

    
    public int GetButtonId()
    {
        return _buttonId;
    }
}
