using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalObjectRegistry;

public class SelectLevelButton : MonoBehaviour
{

    [SerializeField] private int _id;
    private GlobalObjectRegistry _globalObjectRegistry;
    private UnityEngine.UI.Button _button;
    private LevelState _levelState;

    public int ButtonID => _id;


    private void Awake()
    {
        _globalObjectRegistry = GlobalObjectRegistry.instance;
        _button = GetComponent<UnityEngine.UI.Button>();
    }
    private void Start()
    {
        _levelState = _globalObjectRegistry.GetLevelState("Map-Exterior");
        if (_id > _levelState.LastCheckpointID)
        {
            _button.interactable = false;
        }
    }

}
