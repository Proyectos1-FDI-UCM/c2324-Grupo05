using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for the pickable objects
/// Has ID and can be picked up
/// Saves the picked object in the LocalObjectHandler
/// </summary>
public class PickableObject : MonoBehaviour, IPickable
{
    [SerializeField] private int _id;
    protected LocalObjectHandler _localObjectHandler;

    public int ID { get => _id; }

    private void Start() 
    {
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();

    }

    public virtual void PickUp()
    {
        _localObjectHandler.AddPickedObject(ID);
        gameObject.SetActive(false);
    }
    
}