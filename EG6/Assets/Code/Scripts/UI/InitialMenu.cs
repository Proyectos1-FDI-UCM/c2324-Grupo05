using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

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

        Debug.Log("Is egg picked: " + GlobalObjectRegistry.instance.isEggPicked);


        if (GlobalObjectRegistry.instance.isEggPicked == false)
        {
            _continueButton.interactable = false;
            Color current_color = _continueButton.GetComponentInChildren<TMP_Text>().color;
            _continueButton.GetComponentInChildren<TMP_Text>().color = new Color(current_color.r, current_color.g, current_color.b, 0.5f);
        }
        
        if (Input.GetJoystickNames().Length > 0)
        {
            if (_continueButton.interactable)
                EventSystem.current.SetSelectedGameObject(_continueButton.gameObject);
            else
                EventSystem.current.SetSelectedGameObject(_newGameButton.gameObject);
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
