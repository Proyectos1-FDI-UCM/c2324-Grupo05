using System.Collections.Generic;
using UnityEngine;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

/// <summary>
/// This class is used to store the state of the objects in the game between the scenes (on each level).
/// Like the picked objects, opened doors, destroyed objects and the completion state of the level.
/// It is also used to store the global state of the game like the penguin unlock state, egg picked state, collected pieces and trash.
/// </summary>
public class GlobalObjectRegistry : MonoBehaviour
{
    
    public struct LevelState
    {
        public string SceneName;
        public List<int> PickedObjects;
        public List<int> OpenedDoors;
        public List<int> DestroyedObjects;
        public List<int> PressedButtons;
        public int CurrentCheckpointID;
        public int LastCheckpointID;
       

        public LevelState(string sceneName, List<int> pickedObjects, List<int> openedDoors, List<int> pressedButtons,
        List<int> destroyedObjects, int currentCheckpointID)
        {
            SceneName = sceneName;
            PickedObjects = pickedObjects;
            OpenedDoors = openedDoors;
            DestroyedObjects = destroyedObjects;
            PressedButtons = pressedButtons;
            CurrentCheckpointID = currentCheckpointID;
            LastCheckpointID = CurrentCheckpointID;
        }
    }

    private List<LevelState> _levelStates;

    public static GlobalObjectRegistry instance;
    public List<LevelState> LevelStates { get => _levelStates; set => _levelStates = value;}
    public bool isPenguinUnlocked = false;
    public bool isEggPicked = false;
    public int collectedPieces = 0;
    public int collectedTrash = 0;


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

    private void Start()
    {
        GetComponent<SavesManager>().LoadGame();
    }



    public void SaveLevelState(List<int> pickedObjectsIDs, List<int> openedDoorsIDs, List<int> destroyedObjectsIDs,
    List<int> pressedButtonsIDs, int lastCheckpoint, string sceneName = null)
    {
        string currentSceneName = sceneName ?? SceneManager.GetActiveScene().name;
        LevelState currentState = GetLevelState(currentSceneName);
        _levelStates.Remove(currentState);
        
        currentState.PickedObjects = pickedObjectsIDs;
        currentState.OpenedDoors = openedDoorsIDs;
        currentState.DestroyedObjects = destroyedObjectsIDs;
        currentState.PressedButtons = pressedButtonsIDs;
        currentState.CurrentCheckpointID = lastCheckpoint;

        if (currentState.LastCheckpointID < lastCheckpoint)
        {
            currentState.LastCheckpointID = lastCheckpoint;
        }

        
        _levelStates.Add(currentState);

        GetComponent<SavesManager>().SaveGame();
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
        return new LevelState(sceneName, new List<int>(), new List<int>(), new List<int>(), new List<int>(), 1);
    }


    public void StartNewGame()
    {
        _levelStates.Clear();
        GetComponent<SavesManager>().ClearSaves();
        isPenguinUnlocked = false;
        isEggPicked = false;
        collectedPieces = 0;
        collectedTrash = 0;
        GetComponent<SavesManager>().SaveGame();
        SceneManager.LoadScene("Timelines");
    }
}
