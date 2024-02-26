using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class PenguinAI : MovableObject
{
    // Block with private (or protected) _fields

    [SerializeField] Transform _targetTransform;

    NavMeshAgent _navMeshAgent;

    

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
         
    }

    protected void FixedUpdate()
    {
        if (_additionalVector == Vector2.zero)
        {
            _navMeshAgent.SetDestination(_targetTransform.position);
        }
        else
        {
            _navMeshAgent.velocity = (Vector3)_additionalVector + (_targetTransform.position - transform.position).normalized * _movementSpeed;
        }
    }
}
