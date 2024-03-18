using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinWaterTP : MonoBehaviour
{
    [SerializeField] private Teleporting _teleportController;
    [SerializeField] private int _level;

    // Block with custom private Methods 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            //Water death animation
            _teleportController.Teleport(_level);
        }

        /*
        else if(collision.gameObject.GetComponent<PenguinMovement>())
        {
            //Swim animation
        }
        */


    }
}
