using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_controller : MonoBehaviour
{
    // Block with custom classes or structures

    // Block with private (or protected) _fields

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    public GameObject ChildMovement;
    private ChildMovement _Child;
    private void Awake()
    {

        
    }
    private Animation anim;
    private void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        _Child = gameObject.GetComponent<ChildMovement>();
    }

    // MonoBehaviour update methods
    private void Update()
    {
        if (anim.isPlaying)
        {
            return;
        }
        if (_Child.IsMoving & _Child.MovementDirection.x > 0 & _Child.MovementDirection.y > 0)
        {
            anim.Play("WFront_kid");
        }

    }
    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
}
