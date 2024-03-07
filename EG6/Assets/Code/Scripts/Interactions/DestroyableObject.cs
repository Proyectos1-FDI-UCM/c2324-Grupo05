using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class DestroyableObject : MonoBehaviour, IDestroyable, IInteractable
{
    [SerializeField] private int _id;
    private LocalObjectHandler _localObjectHandler;
    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public int ID { get => _id; }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
        _localObjectHandler.DestroyedObjectsIDs.Add(ID);

    }
}
