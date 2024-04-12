using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using LevelState = GlobalObjectRegistry.LevelState;

public class SelectingLevelButton : MonoBehaviour
{
    [SerializeField] private int _id;
    private GlobalObjectRegistry _globalObjectRegistry;
    private UnityEngine.UI.Button _button ;
    private LevelState _levelState ;

    private void Start()
    {
        gameObject.SetActive(true);
        _levelState = _globalObjectRegistry.GetLevelState("Map-Exterior");
        _globalObjectRegistry = GlobalObjectRegistry.instance;
        _button = GetComponent<UnityEngine.UI.Button>();
        if (_id > _levelState.LastCheckpointID)
        {
            _button.interactable = false;
        }
        
    }

    public void LoadLevel()
    {
        

        if (_id > _levelState.LastCheckpointID)
        {
            Debug.Log("You can't load this level yet");
            return;
        }

        _levelState.CurrentCheckpointID = _id;
        _globalObjectRegistry.SaveLevelState(_levelState.PickedObjects, _levelState.OpenedDoors, _levelState.DestroyedObjects, _levelState.PressedButtons, _levelState.CurrentCheckpointID, "Map-Exterior");
        SceneManager.LoadScene("Map-Exterior");
    }

    public void Bedroom()
    {
        SceneManager.LoadScene("BedroomTest");
    }

    
}
