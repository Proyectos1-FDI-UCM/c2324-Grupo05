using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{

    
    public AudioSource Sonido;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            Sonido.Play();


        }


    }


}


