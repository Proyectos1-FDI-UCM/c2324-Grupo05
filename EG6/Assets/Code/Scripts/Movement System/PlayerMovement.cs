using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovableObject
{


    public void SetInputDirection(Vector2 direction)
    {
        _movementDirection = direction;
    }
}
