using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class Button : MonoBehaviour
{
    [SerializeField] protected int _buttonId; 
    protected Renderer _buttonRenderer;

    public int ButtonId { get => _buttonId; private set => _buttonId = value; } // Incapsulated property for the id

    protected virtual void Start() 
    {
        _buttonRenderer = GetComponent<Renderer>();
    }

    protected virtual void OnPressed() 
    {
        
    }
}
