using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class is used as a base class for the buttons in the game.
/// </summary>
[DisallowMultipleComponent]
public abstract class Button : MonoBehaviour
{
    [SerializeField] protected int _buttonId; 
    protected SpriteRenderer _buttonRenderer;
    protected LocalObjectHandler _localObjectHandler;
    protected bool _isPressed = false;

    public bool IsPressed { get => _isPressed; set => _isPressed = value; }
    public int ButtonId { get => _buttonId; private set => _buttonId = value; } 

    protected virtual void Start() 
    {
        _buttonRenderer = GetComponent<SpriteRenderer>();
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if ((collision.GetComponent<ChildMovement>() != null || 
        (collision.GetComponent<PenguinMovement>() != null && collision.GetComponent<PenguinMovement>().ControllingMode == ControllingMode.PlayerControlled)) 
        && _isPressed == false)
        {
            _isPressed = true;
            ButtonPressed();
        }
    }

    protected virtual void ButtonPressed() 
    {
        
    }

    /// <summary>
    /// This method is used to disactivate pressed buttons when we load the level again.
    /// Without sound and execution of the command.
    /// </summary>
    public void DisactivateButton() 
    {
        _isPressed = true;
        _buttonRenderer.sprite = Resources.Load<Sprite>("Sprites/Environment/SpritesFinales/ButtonPressed");
    }
}
