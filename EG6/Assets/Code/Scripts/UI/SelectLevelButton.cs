using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalObjectRegistry;

public class SelectLevelButton : MonoBehaviour
{

    [SerializeField] private int _id;
    [SerializeField] private string _sceneName;
    private GlobalObjectRegistry _globalObjectRegistry;
    private UnityEngine.UI.Button _button;
    private LevelState _levelState;

    public int ButtonID => _id;
    public string SceneName => _sceneName;


    private void Awake()
    {
        _globalObjectRegistry = instance;
        _button = GetComponent<UnityEngine.UI.Button>();
    }
    
    private void Start()
    {
        _levelState = _globalObjectRegistry.GetLevelState(_sceneName);
        if (_id > _levelState.LastCheckpointID)
        {
            _button.interactable = false;
        }
    }

}
