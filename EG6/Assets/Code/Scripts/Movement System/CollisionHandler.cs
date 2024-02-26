using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _collisionOffset = 0.01f;
    [SerializeField] private ContactFilter2D _movementFilter;
    private Rigidbody2D _rigidbody2D;
    private List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>();


    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Check if the object can move in the given direction by casting a ray in that direction
    public bool CheckCollision(Vector2 direction, float movementSpeed) 
    {
        int count = _rigidbody2D.Cast(
            direction,
            _movementFilter,
            _castCollisions,
            movementSpeed * Time.fixedDeltaTime + _collisionOffset);
        Debug.DrawRay(transform.position, direction * movementSpeed * Time.fixedDeltaTime * _collisionOffset, Color.red);
        if (count == 0) 
            {
                return false;
            }
        else
        {
            return true;
        }
    }
}
