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
    protected bool _isPressed = false;

    public bool IsPressed { get => _isPressed; set => _isPressed = value; }
    public int ButtonId { get => _buttonId; private set => _buttonId = value; } // Incapsulated property for the id

    protected virtual void Start() 
    {
        _buttonRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void OnPressed() 
    {
        
    }
}
