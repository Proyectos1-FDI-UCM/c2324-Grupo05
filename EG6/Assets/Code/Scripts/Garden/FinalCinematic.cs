using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCinematic : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null || collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            //Put Cinematic
        }
    }
}
