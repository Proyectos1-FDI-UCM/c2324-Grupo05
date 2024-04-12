using UnityEngine;
using UnityEngine.SceneManagement;
using LevelState = GlobalObjectRegistry.LevelState;

public class SelectingLevelButton : MonoBehaviour
{
    
    private GlobalObjectRegistry _globalObjectRegistry;
    private LevelState _levelState ;

    private void Awake()
    {
        _globalObjectRegistry = GlobalObjectRegistry.instance;

    }

    private void Start()
    {
        gameObject.SetActive(true);
        _levelState = _globalObjectRegistry.GetLevelState("Map-Exterior");
    }

    public void LoadLevel(int indexLevel)
    {
        if (indexLevel > _levelState.LastCheckpointID)
        {
            Debug.Log("You can't load this level yet");
            return;
        }

        _levelState.CurrentCheckpointID = indexLevel;
        _globalObjectRegistry.SaveLevelState(_levelState.PickedObjects, _levelState.OpenedDoors, _levelState.DestroyedObjects, _levelState.PressedButtons, _levelState.CurrentCheckpointID, "Map-Exterior");
        SceneManager.LoadScene("Map-Exterior");
    }

    public void Bedroom()
    {
        SceneManager.LoadScene("BedroomTest");
    }

    
}
