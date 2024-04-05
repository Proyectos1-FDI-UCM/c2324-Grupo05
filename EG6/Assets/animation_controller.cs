using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_controller : MonoBehaviour
{
    
    private ChildMovement _child;
    private Animator _animator;
    float xDir;
    float yDir;
    private void Awake()
    {

        
    }
    private Animation anim;
    private void Start()
    {
        //anim = gameObject.GetComponent<Animation>();
        _animator = gameObject.GetComponent<Animator>();
        _child = gameObject.GetComponent<ChildMovement>();
         float xDir = 0;
         float yDir = 0;
    }

    // MonoBehaviour update methods
    private void Update()
    {
    
            _animator.SetBool("isMoving",_child.IsMoving);
            if (_child.IsMoving) {
                _animator.SetFloat("xDirection", _child.MovementDirection.x );
                _animator.SetFloat("yDirection", _child.MovementDirection.y );
                //save last direction 
                 xDir = _child.MovementDirection.x   ;
                 yDir = _child.MovementDirection.y  ;
            }
            else {
                 _animator.SetFloat("xDirection", xDir );
                _animator.SetFloat("yDirection", yDir );
            }
      
       
    }
    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
}
