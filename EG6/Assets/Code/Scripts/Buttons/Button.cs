using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class Button : MonoBehaviour
{
    [SerializeField] protected int _buttonId; 

    public int ButtonId { get => _buttonId; private set => _buttonId = value; } // Incapsulated property for the id

    protected virtual void OnPressed() 
    {
        
    }
}
