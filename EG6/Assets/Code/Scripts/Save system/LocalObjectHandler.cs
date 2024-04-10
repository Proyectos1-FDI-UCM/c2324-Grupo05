using System.Collections;
using System.Collections.Generic;
using SceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityEngine;
using LevelState = GlobalObjectRegistry.LevelState;
using NavMeshPlus.Components;

/// <summary>
/// This class is used to store the local state of the objects in the level
/// Turns off the objects that were picked, opened or destroyed
/// Saves it to the global object registry when we change or restart the level
/// </summary>
public class LocalObjectHandler : MonoBehaviour
{
    private GlobalObjectRegistry _globalObjectRegistry;

    private Checkpoint _lastCheckpoint;
    private List<int> _pickedObjectsIDs;
    private List<int> _openedDoorsIDs;
    private List<int> _destroyedObjectsIDs;
    private TeleportHandler _teleporter;
    private LevelState _levelState;

    public List<int> PickedObjectsIDs { get => _pickedObjectsIDs; }
    public List<int> OpenedDoorsIDs { get => _openedDoorsIDs; }
    public List<int> DestroyedObjectsIDs { get => _destroyedObjectsIDs; }

    private void Awake()
    {
        _globalObjectRegistry = GlobalObjectRegistry.instance;
        _levelState = _globalObjectRegistry.GetLevelState(SceneManager.GetActiveScene().name);

        _pickedObjectsIDs = new List<int>();
        _openedDoorsIDs = new List<int>();
        _destroyedObjectsIDs = new List<int>();
        _teleporter = FindObjectOfType<TeleportHandler>();
        _pickedObjectsIDs = _levelState.PickedObjects;
        _openedDoorsIDs = _levelState.OpenedDoors;
        _destroyedObjectsIDs = _levelState.DestroyedObjects;

        CharacterDamage[] characterDamages = FindObjectsOfType<CharacterDamage>();
        foreach (CharacterDamage characterDamage in characterDamages)
        {
            characterDamage.SetDamage(_globalObjectRegistry.collectedTrash);
        }

        SetLastCheckpoint(_teleporter.AllCheckpoints[_levelState.CurrentCheckpointID]);
    }

    private void Start() 
    {
        DisableObjects();
        _teleporter.TeleportCharactersToLastCheckpoint(_lastCheckpoint.CheckpointID);
        NavMeshSurface navMeshSurface = FindObjectOfType<NavMeshSurface>();
        navMeshSurface.RemoveData();
        navMeshSurface.BuildNavMesh();
    }

    private void DisableObjects()
    {
        PickableObject[] pickableObjects = FindObjectsOfType<PickableObject>();
        DestroyableObject[] destroyableObjects = FindObjectsOfType<DestroyableObject>();
        DoorSwitcher[] doors = FindObjectsOfType<DoorSwitcher>();

        if (_globalObjectRegistry.isPenguinUnlocked == false)
        {
            FindObjectOfType<PenguinMovement>().gameObject.SetActive(false);
        }

        foreach (PickableObject pickableObject in pickableObjects)
        {
            if (_pickedObjectsIDs.Contains(pickableObject.ID))
            {
                pickableObject.gameObject.SetActive(false);
            }
        }
        foreach (DestroyableObject destroyableObject in destroyableObjects)
        {
            if (_destroyedObjectsIDs.Contains(destroyableObject.ID))
            {
                destroyableObject.gameObject.SetActive(false);
            }
        }
        foreach (DoorSwitcher door in doors)
        {
            if (_openedDoorsIDs.Contains(door.ID))
            {
                door.gameObject.SetActive(false);
            }
        }
    }

    public void SetLastCheckpoint(Checkpoint lastCheckpoint)
    {
        _lastCheckpoint = lastCheckpoint;
        SaveLocalState();
    }

    public void AddPickedObject(int objectID)
    {
        if (!_pickedObjectsIDs.Contains(objectID))
        {
            _pickedObjectsIDs.Add(objectID);
        }
    }

    public void AddOpenedDoor(int doorID)
    {
        if (!_openedDoorsIDs.Contains(doorID))
        {
            _openedDoorsIDs.Add(doorID);
        }
    }

    public void AddDestroyedObject(int objectID)
    {
        if (!_destroyedObjectsIDs.Contains(objectID))
        {
            _destroyedObjectsIDs.Add(objectID);
        }
    }

    public void SaveLocalState()
    {
        _globalObjectRegistry.SaveLevelState(_pickedObjectsIDs, _openedDoorsIDs, _destroyedObjectsIDs, _lastCheckpoint.CheckpointID);
    }
}