using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using LevelState = GlobalObjectRegistry.LevelState;

public class SelectLevelMenu : MonoBehaviour
{
    [Header("First Selected Object")]
    [SerializeField] private GameObject _firstSelectedObject;

    private GlobalObjectRegistry _globalObjectRegistry;
    private LevelState _levelState;
    private SelectLevelButton[] _buttons;

    private void Awake()
    {
        _globalObjectRegistry = GlobalObjectRegistry.instance;

    }

    private void Start()
    {
        gameObject.SetActive(true);

        if (GetComponentInChildren<SelectLevelButton>() != null)
        {
            _buttons = GetComponentsInChildren<SelectLevelButton>();
        }
        if (Input.GetJoystickNames().Length == 0)
        {
            return;
        }
        if (_firstSelectedObject != null)
        {
            EventSystem.current.SetSelectedGameObject(_firstSelectedObject);
        }
    }

    public void LoadLevel(int buttonNumber)
    {
        string sceneName = _buttons[buttonNumber].SceneName;
        int buttonID = _buttons[buttonNumber].ButtonID;
        _levelState = _globalObjectRegistry.GetLevelState(sceneName);
        
        if (buttonID > _levelState.LastCheckpointID)
        {
            return;
        }

        _levelState.CurrentCheckpointID = buttonID;
        _globalObjectRegistry.SaveLevelState(_levelState.PickedObjects, _levelState.OpenedDoors, _levelState.DestroyedObjects, _levelState.PressedButtons, _levelState.CurrentCheckpointID, sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void Bedroom()
    {
        SceneManager.LoadScene("BedroomTest");
    }

    
}
