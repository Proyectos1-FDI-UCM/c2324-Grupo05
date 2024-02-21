using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private CollisionHandler _collisionHandler;
    protected Vector2 _movementDirection; 

    [SerializeField] [Range(1f, 10f)] 
    protected float _movementSpeed = 4f;

    // Speed property which can be changed from another components
    // Round the value to 1 or 10 if it's out of range
    public float MovementSpeed
    {
        get => _movementSpeed;
        set {
            if (value <= 1f)
            {
                _movementSpeed = 1;}
            else if (value >= 10f)
            {
                _movementSpeed = 10f;
            }
            else
            {
                _movementSpeed = value;
            }
        }
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void FixedUpdate()
    {
        Move(_movementDirection);
    }

    public void SetDirection(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void Move(Vector2 direction)
    {
        if (TryMove(direction) == false)
        {
            if (TryMove(new Vector2(direction.x, 0)) == false)
            {
                TryMove(new Vector2(0, direction.y));
            }
        }
    }

    private bool TryMove(Vector2 direction)
    {
        if (_collisionHandler.CheckCollision(direction, _movementSpeed) == false)
        {
            Vector2 moveVector = direction * _movementSpeed * Time.fixedDeltaTime;
            _rigidbody2D.MovePosition(_rigidbody2D.position + moveVector);
            return true;
        }
        return false;
    }
}
