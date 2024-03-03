using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MovableObject
{

    [SerializeField] private Transform _targetTransform;

    NavMeshAgent _navMeshAgent;

    private void Awake()
    {

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
         
    }

    private void FixedUpdate()
    {
        if (_additionalVector == Vector2.zero)
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
        if (_navMeshAgent.velocity.magnitude < 0.1f)
        {
            _navMeshAgent.SetDestination(_targetTransform.position);
        }
    }
}
