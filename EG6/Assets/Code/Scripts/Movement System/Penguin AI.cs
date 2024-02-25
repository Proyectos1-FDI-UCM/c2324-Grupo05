using System.Collections;
using System.Collections.Generic;
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
    private void Update()
    {
        _navMeshAgent.SetDestination(_targetTransform.position);

    }

    // Block with custom classes or structures

    // Block with custom private Methods 



    // Block with custom public Methods (with summary if it has complex logic)
}
