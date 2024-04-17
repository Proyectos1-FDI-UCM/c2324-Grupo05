using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearBotton : MonoBehaviour
{
    [SerializeField] GameObject _bottons;

    private void Start()
    {
        _bottons.SetActive(false);


    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            _bottons.SetActive(true);
            

        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            _bottons.SetActive(false);


        }


    }


}
