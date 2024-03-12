using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Teleporting : MonoBehaviour
{
    // Block with private (or protected) _fields
    [SerializeField] private Transform _penguin;
    [SerializeField] private Transform _kid;
    [SerializeField] private Transform _target0;
    [SerializeField] private Transform _target1;
    [SerializeField] private Transform _target2;
    [SerializeField] private Transform _target3;


    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom classes or structures

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
    public void Teleport(int level)
    {
        if(level == 0)
        {
            _kid.position = _target0.position;
            _penguin.position = _target0.position;
        }
        else if(level == 1)
        {
            _kid.position = _target1.position;
            _penguin.position = _target1.position;
        }
        else if (level == 2)
        {
            _kid.position = _target2.position;
            _penguin.position = _target2.position;
        }
        else if (level == 3)
        {
            _kid.position = _target3.position;
            _penguin.position = _target3.position;
        }



    }




}
