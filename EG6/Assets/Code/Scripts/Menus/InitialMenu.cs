using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{ // Block with private (or protected) _fields



    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {

    }

    private void Start()
    {
        gameObject.SetActive(true);
    }

    // MonoBehaviour update methods
    private void Update()
    {

    }

    // Block with custom classes or structures

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
    
    //Right now will be directeted to level0 but needs to be improved
    public void Continue()
    {
        SceneManager.LoadScene("Map-Exterior");
    }
    /*public void NewGame()
    {
        

    }
    public void Settings()
    {
       
    }
    */
    
    public void Exit()
    {
        if (Application.isEditor)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }





}
