using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

/// <summary>
/// This class is used to store the state of the objects in the game between the scenes (on each level).
/// Like the picked objects, opened doors, destroyed objects and the completion state of the level.
/// </summary>
public class GlobalObjectRegistry : MonoBehaviour
{
    
    public struct LevelState
    {
        public string SceneName;
        public List<int> PickedObjects;
        public List<int> OpenedDoors;
        public List<int> DestroyedObjects;
        public int CurrentCheckpointID;
        public int LastCheckpointID;
       

        public LevelState(string sceneName, List<int> pickedObjects, List<int> openedDoors, List<int> destroyedObjects, int currentCheckpointID)
        {
            SceneName = sceneName;
            PickedObjects = pickedObjects;
            OpenedDoors = openedDoors;
            DestroyedObjects = destroyedObjects;
            CurrentCheckpointID = currentCheckpointID;
            LastCheckpointID = CurrentCheckpointID;
        }
    }

    private List<LevelState> _levelStates;

    public static GlobalObjectRegistry instance;
    public List<LevelState> LevelStates { get => _levelStates; set => _levelStates = value;}
    public bool isPenguinUnlocked = false;
    public int collectedPieces = 0;

    private void Awake()
    {
      
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
            _levelStates = new List<LevelState>();
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    public void SaveLevelState(List<int> pickedObjectsIDs, List<int> openedDoorsIDs, List<int> destroyedObjectsIDs, int lastCheckpoint, string sceneName = null)
    {
        string currentSceneName = sceneName ?? UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        LevelState currentState = GetLevelState(currentSceneName);
        _levelStates.Remove(currentState);
        
        currentState.PickedObjects = pickedObjectsIDs;
        currentState.OpenedDoors = openedDoorsIDs;
        currentState.DestroyedObjects = destroyedObjectsIDs;
        currentState.CurrentCheckpointID = lastCheckpoint;

        if (currentState.LastCheckpointID < lastCheckpoint)
        {
            currentState.LastCheckpointID = lastCheckpoint;
        }

        
        _levelStates.Add(currentState);

        GetComponent<SavesManager>().SaveToFile();
    }


    public LevelState GetLevelState(string sceneName)
    {
        foreach (LevelState state in _levelStates)
        {
            if (state.SceneName == sceneName)
            {
                Debug.Log("Global current checkpoint:" + state.CurrentCheckpointID);
                return state;
            }
        }
        return new LevelState(sceneName, new List<int>(), new List<int>(), new List<int>(), 0);
        
    }
}
