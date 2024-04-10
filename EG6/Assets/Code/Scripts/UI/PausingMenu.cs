using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausingMenu : MonoBehaviour
{
    // Block with private (or protected) _fields

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom classes or structures

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
    public void OnPressedPause()
    {
        gameObject.SetActive(true);
        //parar el tiempo
        Time.timeScale = 0f;
    }
    
    public void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    

    public void LoadScreen()
    {

        SceneManager.LoadScene("InitialMenu");



        /* if (SceneManager.GetActiveScene().buildIndex==0)
         {

             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

         }
         else 
         {

             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }

        */

        

    }
    //SAVE

    public void Bedroom()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BedroomTest");
        
    }
}
