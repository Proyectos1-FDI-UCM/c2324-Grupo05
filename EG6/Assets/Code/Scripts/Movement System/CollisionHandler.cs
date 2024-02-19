using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    
    [SerializeField] private float _collisionOffset = 0.05f;
    [SerializeField] private ContactFilter2D _movementFilter;
    private Rigidbody2D _rigidbody2D;
    private List<RaycastHit2D> _castCollisions = new List<RaycastHit2D>();


    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom classes or structures

    public bool CheckCollision(Vector2 direction, float moveSpeed) 
    {
        int count = _rigidbody2D.Cast(
            direction,
            _movementFilter,
            _castCollisions,
            moveSpeed * Time.fixedDeltaTime + _collisionOffset);

        if (count == 0) 
            {
                return false;
            }
        else
        {
            foreach (RaycastHit2D hit in _castCollisions)
            {
                Debug.Log(hit.ToString());
            }
            return true;
        }
    }
}
