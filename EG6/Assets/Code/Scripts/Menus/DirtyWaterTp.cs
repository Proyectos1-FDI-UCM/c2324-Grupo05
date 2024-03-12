using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyWatertp : MonoBehaviour
{
    [SerializeField] private Teleporting _teleportController;
    [SerializeField] private int _level;

    // Block with custom private Methods 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<ChildMovement>() != null || collision.gameObject.GetComponent<PenguinMovement>())
        {
            //Tiene que espear unos segundos para la animacion de muerte y luego tp
            _teleportController.Teleport(_level);
        }
           



    }


   
}
