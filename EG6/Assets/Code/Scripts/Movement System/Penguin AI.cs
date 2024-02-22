using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PenguinAI : MovableObject
{
    // Block with private (or protected) _fields

    [SerializeField] Transform _targetTransform;

    private Transform _myTransform;

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
        _myTransform = transform; 
    }
    private void Update()
    {
        _movementDirection = _targetTransform.position - _myTransform.position;

    }

    // Block with custom classes or structures

    // Block with custom private Methods 


    //Method to determine how the penguin should move in case that there are walls between him and the player. 
    private void PenguinAi()
    {
        if (_collisionHandler.CheckCollision(_movementDirection,MovementSpeed) == false) 
        {
            _movementDirection = _targetTransform.position - _myTransform.position;
        }
        else
        {
            TryMove(_movementDirection + Vector2.Perpendicular(_movementDirection));
        }
    }

    // Block with custom public Methods (with summary if it has complex logic)
}
