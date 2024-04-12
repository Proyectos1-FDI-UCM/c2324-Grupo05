using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candy : MonoBehaviour
{
    [SerializeField] private GameObject _candy;

    private void Start()
    {
       
        _candy.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null|| collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
                //Show clue menu and stop time
                _candy.SetActive(true);
                Time.timeScale = 1.0f;
           

        }
    }
   


}
