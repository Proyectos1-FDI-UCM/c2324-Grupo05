using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltAnimator : MonoBehaviour
{
    // Block with custom classes or structures

    // Block with private (or protected) _fields
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    // Block with public Properties {get; set;}
    [SerializeField] public float rotationSpeed = 45f;
    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
    public void RotateSprite()
    {
       
        _spriteRenderer.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

    }
}
