using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitcher : MonoBehaviour
{
    private bool _isDoorOpen = false;
    private GameObject _door;

    private void Start()
    {
        _door = gameObject;
    }

    // private method to update the door state based on the _isDoorOpen state
    private void UpdateDoorState()
    {
        if (_isDoorOpen)
        {
            Debug.Log("Door is open");
            _door.SetActive(false);
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
