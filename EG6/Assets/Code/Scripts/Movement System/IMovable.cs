using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    float MovementSpeed { get; set; }

    void SetDirection(Vector2 direction);
}
