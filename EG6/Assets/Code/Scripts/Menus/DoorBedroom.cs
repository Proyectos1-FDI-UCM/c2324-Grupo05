using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBedroom : MonoBehaviour
{
    // Block with private (or protected) _fields
    [SerializeField] private MovableObject _player;
    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom classes or structures

    // Block with custom private Methods 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null) 
        {
            Debug.Log("teletrasport");
            Time.timeScale = 0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        
        }
    }

    // Block with custom public Methods (with summary if it has complex logic)
}
