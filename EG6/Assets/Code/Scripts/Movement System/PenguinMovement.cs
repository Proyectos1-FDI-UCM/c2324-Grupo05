using UnityEngine;
using UnityEngine.AI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


public enum ControllingMode
{
    PlayerControlled,
    AIControlled
}

public enum MovementMode
{
    Walking,
    Swimming
}

/// <summary>
/// This class is used for the movement of the penguin.
/// Uses NavMeshPlus for the AI movement and the MovableObject for the player controlled movement.
/// Uses enum Movement mode to switch between the AI and Player controlled movement (this is not the State pattern!).
/// </summary>
public class PenguinMovement : MovableObject
{
    [SerializeField] private Transform _targetTransform;
    private NavMeshAgent _navMeshAgent;
    private ControllingMode _controllingMode;
    [SerializeField] private MovementMode _movementMode;

    public ControllingMode ControllingMode
    {
        get => _controllingMode;
        set => _controllingMode = value;
    }

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
        _controllingMode = ControllingMode.AIControlled;
    }


    protected override void FixedUpdate()
    {
        switch (_controllingMode)
        {
            case ControllingMode.PlayerControlled:
                Move(_movementDirection);
                break;
            case ControllingMode.AIControlled:
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


    // This method is used to fix when the penguin is stuck in the same position.
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


    protected override void Move(Vector2 direction)
    {
        if (_movementMode == MovementMode.Walking)
        {
            _collisionHandler.CollisionOffset = 0.15f;
            base.Move(direction);
        }
        else if (_movementMode == MovementMode.Swimming)
        {
            _collisionHandler.CollisionOffset = 0.75f;
            Vector2 newPosition = CalculateNewPosition(direction);
            _rigidbody2D.velocity = Vector2.Lerp(_rigidbody2D.velocity, (newPosition - (Vector2)transform.position) / Time.fixedDeltaTime, 0.15f);
        }
    }
}
