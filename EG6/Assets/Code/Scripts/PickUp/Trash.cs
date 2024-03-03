using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : PickableObject
{
    [SerializeField] private TrashCounter _counter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            PickUp();
        }
    }

    public override void PickUp()
    {
        base.PickUp();
        _counter.IncrementCount();
    }
}
