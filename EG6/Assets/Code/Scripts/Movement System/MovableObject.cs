using Vector2 = UnityEngine.Vector2;
using UnityEngine;

/// <summary>
/// Base class for the movable objects in the game.
/// Is used to move kinematic rigidbodies in the game.
/// Has additional vector for the movement to implement conveyor belts and other additional movement effects.
/// </summary>
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
    public Vector2 MovementDirection { get => _movementDirection;}

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
        Vector2 movementDirection = direction * _movementSpeed + _additionalVector;

        float distanceRemaining = movementDirection.magnitude;
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

        Vector2 movementVector =  movementDirection * Time.fixedDeltaTime;
        Debug.Log(movementVector.magnitude);
        Vector2 newPosition = _rigidbody2D.position + movementVector;
        _rigidbody2D.MovePosition(newPosition);
    }
}
