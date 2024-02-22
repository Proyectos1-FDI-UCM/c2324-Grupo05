using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    private Vector2 _movementDirection;
    private float pushSpeed = 3f;

    private void Start() 
    {
        _movementDirection = new Vector2(1, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<MovableObject>() != null)
        {
            MovableObject movableObject = collision.GetComponent<MovableObject>();
            movableObject.AdditionalVector = _movementDirection * pushSpeed;
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
