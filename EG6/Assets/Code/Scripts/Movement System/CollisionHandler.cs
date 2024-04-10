using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to handle the collisions of every movable objects in the game.
/// Our movable objects have a rigidbody2D isKinematic, so we need to handle the collisions manually.
/// </summary>
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _collisionOffset = 0.05f;
    [SerializeField] private ContactFilter2D _movementFilter;
    
    private List<RaycastHit2D> _movementDirectionHits = new List<RaycastHit2D>();
    private Rigidbody2D _rigidbody2D;

    public float CollisionOffset { get => _collisionOffset; set => _collisionOffset = value; }


    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// This method casts a ray in the movement direction of the object and checks for collisions.
    /// As parameters, it takes the remaining distance to move and the movement direction.
    /// To handle sliding on walls, we subtract the normal of the hit from the movement direction.
    /// </summary>
    /// <param name="distanceRemaining"> reference to the distance remaining to move </param>
    /// <param name="movementDirection"> reference to the movement direction </param>
    public void CheckCollisions(ref float distanceRemaining, ref Vector2 movementDirection)
    {
        float distance = distanceRemaining;
        int hitCount = _rigidbody2D.Cast(movementDirection, _movementFilter, _movementDirectionHits, distance);

        if (hitCount == 0)
        {
            return;
        }
        
        RaycastHit2D hit = _movementDirectionHits[0];

        if (hit.distance > _collisionOffset)
        {
            return;
        }

        distance = 0f;
        movementDirection -=  hit.normal * Vector2.Dot(movementDirection, hit.normal);
        distanceRemaining -= distance;
    }
}
