using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class DoorSwitcher : MonoBehaviour
{
    private int _id;
    private bool _isDoorOpen = false;
    private LocalObjectHandler _localObjectHandler;
    private GameObject _door;

    public int ID { get => _id;}

    private void Start()
    {
        _door = gameObject;
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
    }

    // private method to update the door state based on the _isDoorOpen state
    private void UpdateDoorState()
    {
        if (_isDoorOpen)
        {
            Debug.Log("Door is open");
            _door.SetActive(false);
            _localObjectHandler.OpenedDoorsIDs.Add(ID);
        }
        else
        {
            Debug.Log("Door is closed");
            _door.SetActive(true);
        }
    }

    /// <summary>
    /// Method to set the door state (opened or closed)
    /// </summary>
    /// <param name="state">true if door is opened, false if it's closed</param>
    public void SetDoorState(bool state)
    {
        _isDoorOpen = state;
        UpdateDoorState();
    }
}
