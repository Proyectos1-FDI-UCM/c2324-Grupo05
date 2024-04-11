using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    // Block with custom classes or structures

    // Block with private (or protected) _fields
    private bool FullTrash;
    // Block with public Properties {get; set;}
    public GameObject Logro1;
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

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
    public void ShowAchive()
    {
        if (GlobalObjectRegistry.instance.collectedTrash == 46)
        {
            FullTrash = true;
            Logro1.SetActive(true);
        }
    }
}
