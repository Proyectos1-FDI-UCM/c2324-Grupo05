using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidTestt : MonoBehaviour
{
    // Block with custom classes or structures

    // Block with private (or protected) _fields
    private Animator animator;
    // Block with public Properties {get; set;}
    public delegate void AnimationFinishedHandler();
    public static event AnimationFinishedHandler OnAnimationFinished;
    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // MonoBehaviour update methods
    private void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);

            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        
    }

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)

    public void AnimationFinished()
    {
        if (OnAnimationFinished != null)
        {
            OnAnimationFinished();
        }
    }
}
