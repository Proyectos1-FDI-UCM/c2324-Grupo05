using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to store the state of the objects in the game between the scenes.
/// Like the picked objects, opened doors, destroyed objects and the completion state of the level etc.
/// </summary>
public class GlobalObjectRegistry : MonoBehaviour
{
    public struct LevelState
    {
        public string sceneName;
        public bool isCompleted;
        public List<int> pickedObjects;
        public List<int> openedDoors;
        public List<int> destroyedObjects;

        public LevelState(string sceneName, bool isCompleted, List<int> pickedObjects, List<int> openedDoors, List<int> destroyedObjects)
        {
            this.sceneName = sceneName;
            this.isCompleted = isCompleted;
            this.pickedObjects = pickedObjects;
            this.openedDoors = openedDoors;
            this.destroyedObjects = destroyedObjects;
        }
    }

    private List<LevelState> _levelStates;

    public static GlobalObjectRegistry instance;
    public List<LevelState> LevelStates { get => _levelStates;}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Помечаем текущий объект как не уничтожаемый при загрузке новой сцены
            _levelStates = new List<LevelState>();
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликат
        }
    }

    public void SaveLevelState(List<int> pickedObjectsIDs, List<int> openedDoorsIDs, List<int> destroyedObjectsIDs)
    {
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        LevelState currentState = GetLevelState(currentSceneName);
        currentState.isCompleted = true;
        currentState.pickedObjects = pickedObjectsIDs;
        currentState.openedDoors = openedDoorsIDs;
        currentState.destroyedObjects = destroyedObjectsIDs;

        _levelStates.Remove(currentState);
        _levelStates.Add(currentState);
    }


    public LevelState GetLevelState(string sceneName)
    {
        foreach (LevelState state in _levelStates)
        {
            if (state.sceneName == sceneName)
            {
                return state;
            }
        }
        return new LevelState(sceneName, false, new List<int>(), new List<int>(), new List<int>());
    }
}
