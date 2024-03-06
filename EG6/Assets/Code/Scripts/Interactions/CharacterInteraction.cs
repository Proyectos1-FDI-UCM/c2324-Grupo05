using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _interactionFilter;
    [SerializeField] private float _interactionDistance = 2f;

    private List<RaycastHit2D> _interactionHits = new List<RaycastHit2D>();
    private Rigidbody2D _rigidbody2D;
    private MovableObject _movableObject;
    private Vector2 _direction;
    private GameObject _selectedObject;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movableObject = GetComponent<MovableObject>();
    }

    private void Update() 
    {
        UpdateInteractionDirection(_movableObject.MovementDirection);
        CheckInteractions(_direction);
    }

    private void CheckInteractions(Vector2 direction)
    {
        int hitCount = _rigidbody2D.Cast(direction, _interactionFilter, _interactionHits, _interactionDistance);

        if (hitCount > 0)
        {
            _selectedObject = _interactionHits[0].collider.gameObject;
            
        }
    }

    private void UpdateInteractionDirection(Vector2 direction)
    {
        if (direction != _direction && direction != Vector2.zero)
        {
            _direction = direction;
        }
    }
}
