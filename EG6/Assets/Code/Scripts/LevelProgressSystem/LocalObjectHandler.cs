using System.Collections;
using System.Collections.Generic;
using SceneManager = UnityEngine.SceneManagement.SceneManager;
using UnityEngine;

/// <summary>
/// This class is used to store the local state of the objects in the level
/// Then save it to the global object registry
/// </summary>
public class LocalObjectHandler : MonoBehaviour
{
    private GlobalObjectRegistry _globalObjectRegistry;

    private List<int> _pickedObjectsIDs;
    private List<int> _openedDoorsIDs;
    private List<int> _destroyedObjectsIDs;

    public List<int> PickedObjectsIDs { get => _pickedObjectsIDs; }
    public List<int> OpenedDoorsIDs { get => _openedDoorsIDs; }
    public List<int> DestroyedObjectsIDs { get => _destroyedObjectsIDs; }

    private void Awake()
    {
        _pickedObjectsIDs = new List<int>();
        _openedDoorsIDs = new List<int>();
        _destroyedObjectsIDs = new List<int>();
    }

    private void Start() 
    {
        _globalObjectRegistry = GlobalObjectRegistry.instance;
        _pickedObjectsIDs = _globalObjectRegistry.GetLevelState(SceneManager.GetActiveScene().name).pickedObjects;
        _openedDoorsIDs = _globalObjectRegistry.GetLevelState(SceneManager.GetActiveScene().name).openedDoors;
        _destroyedObjectsIDs = _globalObjectRegistry.GetLevelState(SceneManager.GetActiveScene().name).destroyedObjects;

        DisableObjects();
    }

    private void DisableObjects()
    {
        PickableObject[] pickableObjects = FindObjectsOfType<PickableObject>();
        DestroyableObject[] destroyableObjects = FindObjectsOfType<DestroyableObject>();
        DoorSwitcher[] doors = FindObjectsOfType<DoorSwitcher>();

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

    public void AddPickedObject(int objectID)
    {
        if (!_pickedObjectsIDs.Contains(objectID))
        {
            _pickedObjectsIDs.Add(objectID);
        }
        Debug.Log("Picked object ID: " + objectID);
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
        _globalObjectRegistry.SaveLevelState(_pickedObjectsIDs, _openedDoorsIDs, _destroyedObjectsIDs);
        Debug.Log("Local level state was successfully saved" +
        "\nPicked objects: " + _pickedObjectsIDs.Count + 
        "\nOpened doors: " + _openedDoorsIDs.Count + 
        "\nDestroyed objects: " + _destroyedObjectsIDs.Count);
    }
}
