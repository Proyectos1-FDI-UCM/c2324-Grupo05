using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using Vector2 = UnityEngine.Vector2;
using UnityEngine;

public class MovableObject : MonoBehaviour, IMovable
{
    [SerializeField] private float _maxIterations = 2f;

    protected Rigidbody2D _rigidbody2D;
    protected CollisionHandler _collisionHandler;
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

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    protected virtual void FixedUpdate()
    {
        Move(_movementDirection);
    }

    public virtual void SetInputDirection(Vector2 direction)
    {
        _movementDirection = direction;
    }

    protected virtual void Move(Vector2 direction)
    {
        Vector2 movementDirection = direction;

        float totalSpeed = _movementSpeed;
        float distanceRemaining = Mathf.Min(totalSpeed * Time.fixedDeltaTime, movementDirection.magnitude);
        float maxIterations = _maxIterations;
        const float Epsilon = 0.005f;
        
        while (
            maxIterations-- > 0 &&
            distanceRemaining > Epsilon &&
            movementDirection.sqrMagnitude > Epsilon
            )
        {
            _collisionHandler.CheckCollisions(ref distanceRemaining, ref movementDirection);
        };

        Vector2 movementVector =  movementDirection.normalized * distanceRemaining + _additionalVector * Time.fixedDeltaTime;
        Vector2 newPosition = _rigidbody2D.position + movementVector;
        _rigidbody2D.MovePosition(newPosition);
    }
}
