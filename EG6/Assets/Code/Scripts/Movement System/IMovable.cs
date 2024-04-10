using UnityEngine;

/// <summary>
/// Interface for the movable objects
/// </summary>
public interface IMovable
{
    float MovementSpeed { get; set; }

    Vector2 AdditionalVector { get; set; }
}
