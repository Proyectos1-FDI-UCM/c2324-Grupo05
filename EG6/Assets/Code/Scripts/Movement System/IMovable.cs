using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    float MovementSpeed { get; set; }

    Vector2 AdditionalVector { get; set; }
}
