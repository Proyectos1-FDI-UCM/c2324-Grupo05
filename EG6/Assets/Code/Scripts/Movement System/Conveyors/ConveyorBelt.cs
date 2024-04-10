using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class is used to move objects that are inside the trigger area of the conveyor belt.
/// It can move objects only if they have the MovableObject component.
/// </summary>
public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private Vector2 _movementDirection;
    [SerializeField] private float _pushSpeed = 2f;

    public Vector2 MovementDirection { get => _movementDirection; set => _movementDirection = value; }

    private void Start() 
    {
        _movementDirection = _movementDirection.normalized;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<MovableObject>() != null)
        {
            MovableObject movableObject = collision.GetComponent<MovableObject>();
            movableObject.AdditionalVector = _movementDirection * _pushSpeed;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MovableObject>() != null)
        {
            MovableObject movableObject = collision.GetComponent<MovableObject>();
            movableObject.AdditionalVector = Vector2.zero;
        }
    }
}
