using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{ 

    [Header("First Selected Object")]
    [SerializeField] private GameObject _firstSelectedObject;

    private void Start()
    {
        gameObject.SetActive(true);

        if (Input.GetJoystickNames().Length == 0)
        {
            return;
        }
        if (_firstSelectedObject != null)
        {
            EventSystem.current.SetSelectedGameObject(_firstSelectedObject);
        }
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
