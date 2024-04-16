using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionSpriteController : MonoBehaviour
{
    [SerializeField] private Sprite[] _evolutionSprite = new Sprite[4];
    //[SerializeField] private Animator[] _evolutionAnimation = new Animator[3];

    private SpriteRenderer _spriteRenderer;
    //private Animator _penguinAnimator;


   

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_penguinAnimator = GetComponent<Animator>();
    }

    // MonoBehaviour update methods
    private void Update()
    {
        //penguin shows the sprite and animator based on how many pieces the player has collected
        _spriteRenderer.sprite = _evolutionSprite[GlobalObjectRegistry.instance.collectedPieces];
        //_penguinAnimator = _evolutionAnimation[GlobalObjectRegistry.instance.collectedPieces];



    }

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
}
