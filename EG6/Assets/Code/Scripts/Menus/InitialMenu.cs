using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{ 
    private void Start()
    {
        gameObject.SetActive(true);
    }

    public void Continue()
    {
        SceneManager.LoadScene("BedroomTest");
    }

    public void NewGame()
    {
        GlobalObjectRegistry.instance.StartNewGame();
    }
    
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
