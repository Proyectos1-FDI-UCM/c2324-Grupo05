using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_controller : MonoBehaviour
{
    
    private ChildMovement _child;
    private Animator _animator;
    private void Awake()
    {

        
    }
    private Animation anim;
    private void Start()
    {
        //anim = gameObject.GetComponent<Animation>();
        _animator = gameObject.GetComponent<Animator>();
        _child = gameObject.GetComponent<ChildMovement>();
    }

    // MonoBehaviour update methods
    private void Update()
    {
    
            _animator.SetBool("isMoving",_child.IsMoving);
            if (_child.IsMoving) {
                _animator.SetFloat("xDirection", _child.MovementDirection.x );
                _animator.SetFloat("yDirection", _child.MovementDirection.y );
            }
           
      
       
    }
    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
}
