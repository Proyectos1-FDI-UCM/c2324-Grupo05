using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    [SerializeField] private float _collisionOffset = 0.01f;
    [SerializeField] private float _maxIterations = 2f;
    [SerializeField] private ContactFilter2D _movementFilter;

    private Rigidbody2D _rigidbody2D;
    protected CollisionHandler _collisionHandler;
    protected Vector2 _movementDirection; 
    protected Vector2 _additionalVector;
    private List<RaycastHit2D> _movementDirectionHits = new List<RaycastHit2D>();

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

    protected virtual void Move(Vector2 direction)
    {
        // Grab the input movement unit direction.
        Vector2 movementDirection = direction + _additionalVector; 

        float totalSpeed = _movementSpeed + _additionalVector.magnitude;

        // Calculate how much distance we'd like to cover this update.
        float distanceRemaining = Mathf.Min(totalSpeed * Time.fixedDeltaTime, movementDirection.magnitude);
        
        float maxIterations = _maxIterations;

        // We're going to be repositioning the Rigidbody2D during the query iterations so we'll need to keep a note of its starting position.
        // NOTE: As mentioned below, we can avoid this altogether.
        var startPosition = _rigidbody2D.position;

        // Iterate up to a capped iteration limit or until we have no distance to move or we've clamped the direction of motion to zero.
        const float Epsilon = 0.005f;
        while(
            maxIterations-- > 0 &&
            distanceRemaining > Epsilon &&
            movementDirection.sqrMagnitude > Epsilon
            )
        {
            var distance = distanceRemaining;

            // Perform a cast in the current movement direction using the colliders on the Rigidbody.
            // Note: A potentially better way of doing this is to do an arbitrary shape cast such as Physics2D.CapsuleCast/BoxCast etc.
            // At least when performing a specific shape query, we have no need to reposition the Rigidbody2D before each query.
            var hitCount = _rigidbody2D.Cast(movementDirection, _movementFilter, _movementDirectionHits, distance);

            // Did we have any hits?
            if (hitCount > 0)
            {
                // Yes, so for this controller we're only interested in the first results which is the first hit.
                var hit = _movementDirectionHits[0];

                // We're only interested in movement if it's beyond the contact offset.
                if (hit.distance > _collisionOffset)
                {
                    // Calculate the distance we'd like to move.
                    distance = hit.distance - _collisionOffset;

                    // Reposition the Rigidbody2D to the hit point.
                    // NOTE: Again, this can be avoided by a different choice of query.
                    _rigidbody2D.position += movementDirection * distance;
                }
                else
                {
                    // We had a hit but it resulted in us touching or being inside the contact offset.
                    distance = 0f;
                }

                // Clamp the movement direction.
                // NOTE: This is effectively how we iterate and change direction for the queries.
                movementDirection -=  hit.normal * Vector2.Dot(movementDirection, hit.normal);
            }
            else
            {
                // No hit so move by the whole distance.
                _rigidbody2D.position += movementDirection * distance;
            }

            // Remove the distance we ended up moving from the remaining.
            distanceRemaining -= distance;
        };

        // Reset the Rigidbody2D position due to changes during querying.
        // NOTE: We can avoid this setting of the Rigidbody2D position by a different choice of query.
        var targetPosition = _rigidbody2D.position;
        _rigidbody2D.position = startPosition;

        // Set-up a move for the Rigidbody2D.
        // NOTE: Technically here we're moving in a direct line to the final position but we potentially found
        // this position in separate directions but if the time-step and speed is small, it's not going to be a problem.
        _rigidbody2D.MovePosition(targetPosition);
    }

    
    
}
