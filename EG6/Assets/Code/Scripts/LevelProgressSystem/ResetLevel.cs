using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    private LocalObjectHandler _localObjectHandler;


    private void Start()
    {
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            //_localObjectHandler.SaveLocalState();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Reset Level placeholder");
        }
    }
}

