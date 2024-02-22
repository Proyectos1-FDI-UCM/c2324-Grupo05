using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private CollisionHandler _collisionHandler;
    protected Vector2 _movementDirection; 
    protected Vector2 _additionalVector;

    [SerializeField] [Range(1f, 10f)] 
    protected float _movementSpeed = 4f;

    public Vector2 AdditionalVector { get => _additionalVector; set => _additionalVector = value;}
    public float MovementSpeed
    {
        get => _movementSpeed;
        set {
            if (value <= 0f)
            {
                _movementSpeed = 0;}
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
            Vector2 movingVector = SetMovingVector(direction, _movementSpeed, _additionalVector);
            _rigidbody2D.MovePosition(_rigidbody2D.position + movingVector * Time.fixedDeltaTime);
            return true;
        }
        return false;
    }

    public void SetDirection(Vector2 direction)
    {
        _movementDirection = direction;
    }

    protected Vector2 SetMovingVector(Vector2 direction, float speed, Vector2 additionalVector)
    {
        return direction * speed  + additionalVector;
    }
    
}
