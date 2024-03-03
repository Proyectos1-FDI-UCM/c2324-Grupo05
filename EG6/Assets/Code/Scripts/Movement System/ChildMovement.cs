using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMovement : MovableObject
{
    public override void SetInputDirection(Vector2 direction)
    {
        _movementDirection = direction;
    }

}
