using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineCinematic : MonoBehaviour
{
    [SerializeField] GameObject _submarine;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null && collision.gameObject.GetComponent<PenguinMovement>() != null)
        {

            //Show cinemtatic of the submarine

        }
    }
}
