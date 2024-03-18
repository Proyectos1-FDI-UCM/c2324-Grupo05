using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelState = GlobalObjectRegistry.LevelState;

public class SelectingLevelButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private GlobalObjectRegistry _globalObjectRegistry;

    private void Start()
    {
        gameObject.SetActive(true);
        _globalObjectRegistry = GlobalObjectRegistry.instance;
    }

    public void LoadLevel(int indexLevel)
    {
        LevelState levelState = _globalObjectRegistry.GetLevelState("Map-Exterior");
        levelState.currentCheckpoint = indexLevel;
        _globalObjectRegistry.SaveLevelState(levelState.pickedObjects, levelState.openedDoors, levelState.destroyedObjects, levelState.currentCheckpoint, "Map-Exterior");
        SceneManager.LoadScene("Map-Exterior");
    }

    public void Bedroom()
    {
        SceneManager.LoadScene("BedroomTest");
    }

    public void Back()
    {
        _pauseMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
