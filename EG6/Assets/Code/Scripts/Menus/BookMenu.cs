using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;


    private void Start()
    {
        _menu.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {

            _menu.SetActive(true);
            Time.timeScale = 0f;

        }


    }

   
}
