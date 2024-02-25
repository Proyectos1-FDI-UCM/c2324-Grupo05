using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Piece : PickableObject
{
    [SerializeField] private PieceCounter _counter;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            PickUp();
        }
    }

    public override void PickUp()
    {   
        base.PickUp(); // base. is used to call method PickUp from PickableObject class and then execute additional code below
        _counter.IncrementCount();
    }
}
