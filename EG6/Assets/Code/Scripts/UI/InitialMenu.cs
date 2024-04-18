using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{ 

    [Header("First Selected Object")]
    [SerializeField] private UnityEngine.UI.Button _newGameButton;
    [SerializeField] private UnityEngine.UI.Button _continueButton;
    private SavesManager _savesManager;

    private void Start()
    {
        gameObject.SetActive(true);
        _savesManager = FindObjectOfType<SavesManager>();

        if (Input.GetJoystickNames().Length == 0)
        {
            return;
        }

        if (GlobalObjectRegistry.instance.isEggPicked == false)
        {
            _continueButton.interactable = false;
            EventSystem.current.SetSelectedGameObject(_newGameButton.gameObject);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(_continueButton.gameObject);
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
            _savesManager.SaveGame();
            Application.Quit();
        }
    }
}
