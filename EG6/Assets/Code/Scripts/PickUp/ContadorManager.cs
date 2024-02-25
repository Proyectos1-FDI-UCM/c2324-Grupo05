using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorManager : MonoBehaviour
{
    // Block with private (or protected) _fields
    //contadores:
    private int Ntrash = 0;
    private int Npieza = 0;

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
    public void PiezaContador()
    {
        Npieza++;
    }

    public void TrashContador()
    {
        Ntrash++;
    }
}
