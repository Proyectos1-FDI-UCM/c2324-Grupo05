using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNewInput : MonoBehaviour
{
    private MovableObject _movableObject;
    private Vector2 _inputDirection;

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        _movableObject = GetComponent<MovableObject>();
    }

    // MonoBehaviour update methods
    private void FixedUpdate()
    {
        _inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _movableObject.SetInput(_inputDirection);
    }

    // Block with custom classes or structures

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
}
