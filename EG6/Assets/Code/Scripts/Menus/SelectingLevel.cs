using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelState = GlobalObjectRegistry.LevelState;

public class SelectingLevelButton : MonoBehaviour
{
    private GlobalObjectRegistry _globalObjectRegistry;

    private void Start()
    {
        gameObject.SetActive(true);
        _globalObjectRegistry = GlobalObjectRegistry.instance;
    }

    public void LoadLevel(int indexLevel)
    {
        LevelState levelState = _globalObjectRegistry.GetLevelState("Map-Exterior");

        if (indexLevel > levelState.LastCheckpointID)
        {
            Debug.Log("You can't load this level yet");
            return;
        }

        levelState.CurrentCheckpointID = indexLevel;
        _globalObjectRegistry.SaveLevelState(levelState.PickedObjects, levelState.OpenedDoors, levelState.DestroyedObjects, levelState.CurrentCheckpointID, "Map-Exterior");
        SceneManager.LoadScene("Map-Exterior");
    }

    public void Bedroom()
    {
        SceneManager.LoadScene("BedroomTest");
    }

    
}
