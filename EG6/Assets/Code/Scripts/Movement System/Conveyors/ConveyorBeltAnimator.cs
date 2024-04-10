using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltAnimator : MonoBehaviour
{
    // Block with custom classes or structures

    // Block with private (or protected) _fields
    private SpriteRenderer _spriteRenderer;
    // Block with public Properties {get; set;}
    [SerializeField] public float rotationSpeed = 45f;
    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
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
        
       if (gameObject.CompareTag("A")) //verificar si tiene la etiqueta
       {
            Vector3 currentScale = _spriteRenderer.transform.localScale;   //rotar el objeto en vertical
            currentScale.y *= -1;
            _spriteRenderer.transform.localScale = currentScale;

       }
       else
       {
            Vector3 currentScale = _spriteRenderer.transform.localScale;     //rotar el objeto en horizontal
            currentScale.x *= -1;
            _spriteRenderer.transform.localScale = currentScale;

       }
        
    }
}
