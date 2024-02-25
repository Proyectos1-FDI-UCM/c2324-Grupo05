using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Piece : PickableObject
{
    // Block with private (or protected) _fields
    [SerializeField] private Counting _counter;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {

            PickUp();

        }
    }
    // Block with custom public Methods (with summary if it has complex logic)

    public override void PickUp()
        {   
            base.PickUp();
        // Here could be any logic
        _counter.CounterPiece();
        Debug.Log("You picked up a part.");
        }
}
