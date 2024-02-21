using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private CollisionHandler _collisionHandler;
    protected Vector2 _movementDirection;    
    [SerializeField] [Range(1f, 10f)] protected float _movementSpeed = 4f;

    public float MovementSpeed
    {
        get => _movementSpeed;
        set {
            if (value >= 1f && value <= 10f)
            {
                _movementSpeed = 4;
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

    // MonoBehaviour update methods
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

    // Block with custom public Methods (with summary if it has complex logic)
}
