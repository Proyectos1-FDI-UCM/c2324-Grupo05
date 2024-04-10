using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class is used to set the last checkpoint when the child passes through it
/// Also picking up pieces will set the last checkpoint using reference to this class
/// </summary>
public class Checkpoint : MonoBehaviour
{
    private LocalObjectHandler _localObjectHandler;
    [SerializeField] private int _checkpointID;

    public int CheckpointID { get => _checkpointID;}

    private void Start() 
    {
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            _localObjectHandler.SetLastCheckpoint(this);
        }
    }
}
