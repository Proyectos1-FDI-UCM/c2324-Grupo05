using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used as a base class for the child movement in the game.
/// Inherits from MovableObject, but sets the input direction to the movement direction.
/// </summary>
public class ChildMovement : MovableObject
{
    public override void SetInputDirection(Vector2 direction)
    {
        _movementDirection = direction;
    }
}
