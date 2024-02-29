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

        int hitCount = _rigidbody2D.Cast(movementDirection, _movementFilter, _movementDirectionHits, distance);

        if (hitCount > 0)
        {
            RaycastHit2D hit = _movementDirectionHits[0];

            if (hit.distance > _collisionOffset)
            {
                distance = hit.distance - _collisionOffset;

                _rigidbody2D.position += movementDirection * distance;
            }
            else
            {
                distance = 0f;
            }

            movementDirection -=  hit.normal * Vector2.Dot(movementDirection, hit.normal);
        }
        else
        {
            _rigidbody2D.position += movementDirection * distance;
        }

        distanceRemaining -= distance;
    }
}
