using UnityEngine;
using UnityEngine.SceneManagement;
using LevelState = GlobalObjectRegistry.LevelState;

public class DoorToDungeon : MonoBehaviour
{
    private GlobalObjectRegistry _globalObjectRegistry;

    private void Start()
    {
        _globalObjectRegistry = GlobalObjectRegistry.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ChildMovement>() != null)
        {
            LevelState lastLevelState = _globalObjectRegistry.GetLevelState("Level3");
            lastLevelState.CurrentCheckpointID = 0;
            _globalObjectRegistry.SaveLevelState(lastLevelState.PickedObjects, lastLevelState.OpenedDoors, lastLevelState.DestroyedObjects, lastLevelState.PressedButtons, lastLevelState.CurrentCheckpointID, "Level3");
            SceneManager.LoadScene("Level3");
        }
    }
}
