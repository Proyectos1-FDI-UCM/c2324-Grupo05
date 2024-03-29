using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.SocialPlatforms;

/// <summary>
/// This class defines the destroyable objects in the game
/// And save the state of the destroyed objects in the LocalObjectHandler
/// This is generic class that can be inherited by other classes
/// </summary>
public class DestroyableObject : MonoBehaviour, IDestroyable, IInteractable
{
    [SerializeField] private int _id;
    protected int _durability = 3;
    protected bool _isSelected = false;

    protected LocalObjectHandler _localObjectHandler;
    protected SpriteRenderer _spriteRenderer;
    protected NavMeshSurface _navMeshSurface;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public int ID { get => _id; }

    protected virtual void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
        _navMeshSurface = FindObjectOfType<NavMeshSurface>();
    }

    private void Update() 
    {
        if (_isSelected)
        {
            _spriteRenderer.color = Color.red;
        }
        else
        {
            _spriteRenderer.color = Color.white;
        }
    }

    public virtual void Destroy()
    {
        gameObject.SetActive(false);
        _navMeshSurface.RemoveData();
        _navMeshSurface.BuildNavMesh();
        _localObjectHandler.DestroyedObjectsIDs.Add(ID);
    }

    public virtual void PerformInteraction()
    {
        if (_durability > 0)
        {
            _durability--;
            if (_durability == 0)
            {
                Destroy();
            }
        }
    }

    public virtual void Select()
    {
        _isSelected = true;
    }

    public virtual void Deselect()
    {
        _isSelected = false;
    }
}
