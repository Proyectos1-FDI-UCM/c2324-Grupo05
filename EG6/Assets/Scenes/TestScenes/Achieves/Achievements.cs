using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    // Block with custom classes or structures

    // Block with private (or protected) _fields
    private bool FullTrash;
    private bool Friend;
    // Block with public Properties {get; set;}
    public Animator animator;
    public GameObject Logro1;
    public GameObject Logro2;
    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        animator = animator.GetComponent<Animator>();
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
    public void ShowAchive()
    {
        if (GlobalObjectRegistry.instance.collectedTrash == 1)
        {
            FullTrash = true;
            Logro1.SetActive(true);
            PlayerPrefs.SetInt("Logro1", Logro1 ? 1 : 0);
            animator.Play("Logro1");
        }

        if (GlobalObjectRegistry.instance.isEggPicked)
        {
            Friend = true;
            Logro2.SetActive(true);
            PlayerPrefs.SetInt("Logro2", Logro2 ? 1 : 0);
        }


    }
}
