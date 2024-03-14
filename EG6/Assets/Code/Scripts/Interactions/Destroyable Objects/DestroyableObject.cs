using System.Collections;
using System.Collections.Generic;
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
    protected LocalObjectHandler _localObjectHandler;
    protected SpriteRenderer _spriteRenderer;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public int ID { get => _id; }

    protected virtual void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
    }

    public virtual void Destroy()
    {
        gameObject.SetActive(false);
        _localObjectHandler.DestroyedObjectsIDs.Add(ID);
    }

    public virtual void Select()
    {
        _spriteRenderer.color = Color.red;
    }

    public virtual void Deselect()
    {
        _spriteRenderer.color = Color.white;
    }
}
