using UnityEngine;
using UnityEngine.AI;

public enum MovementMode
{
    PlayerControlled,
    AIControlled
}

public class PenguinMovement : MovableObject
{
    [SerializeField] private Transform _targetTransform;
    private NavMeshAgent _navMeshAgent;
    private MovementMode _movementMode;

    public MovementMode MovementMode
    {
        get => _movementMode;
        set => _movementMode = value;
    }

    private void Awake()
    {  
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collisionHandler = GetComponent<CollisionHandler>();
        _movementMode = MovementMode.AIControlled;
    }

    protected override void FixedUpdate()
    {
        switch (_movementMode)
        {
            case MovementMode.PlayerControlled:
                Move(_movementDirection);
                break;
            case MovementMode.AIControlled:
                HandleAIMovement();
                break;
        }
    }

    private void HandleAIMovement()
    {
        if (_additionalVector == Vector2.zero && _navMeshAgent.enabled)
        {
            _navMeshAgent.SetDestination(_targetTransform.position);
        }
        else
        {
            _navMeshAgent.velocity = (Vector3)_additionalVector + (_targetTransform.position - transform.position).normalized * _movementSpeed;
        }
        IdleWalking();
    }


    private void IdleWalking()
    {
        if (_navMeshAgent.velocity.magnitude < 0.1f && _navMeshAgent.enabled)
        {
            _navMeshAgent.SetDestination(_targetTransform.position);
        }
    }

    public override void SetInputDirection(Vector2 direction)
    {
        _movementDirection = direction;
    }
}
