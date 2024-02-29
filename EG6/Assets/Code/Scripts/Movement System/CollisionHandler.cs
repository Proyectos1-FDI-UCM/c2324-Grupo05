using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _collisionOffset = 0.01f;
    [SerializeField] private ContactFilter2D _movementFilter;
    
    private List<RaycastHit2D> _movementDirectionHits = new List<RaycastHit2D>();
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void CheckCollisions(ref float distanceRemaining, ref Vector2 movementDirection)
    {
        float distance = distanceRemaining;

            // Perform a cast in the current movement direction using the colliders on the Rigidbody.
            // Note: A potentially better way of doing this is to do an arbitrary shape cast such as Physics2D.CapsuleCast/BoxCast etc.
            // At least when performing a specific shape query, we have no need to reposition the Rigidbody2D before each query.
            int hitCount = _rigidbody2D.Cast(movementDirection, _movementFilter, _movementDirectionHits, distance);

            // Did we have any hits?
            if (hitCount > 0)
            {
                // Yes, so for this controller we're only interested in the first results which is the first hit.
                RaycastHit2D hit = _movementDirectionHits[0];

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
    }
}
