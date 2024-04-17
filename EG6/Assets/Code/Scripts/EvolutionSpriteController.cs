using UnityEngine;

/// <summary>
/// This class is responsible for changing the sprite of the penguin based on how many pieces the player has collected.
/// </summary>
public class EvolutionSpriteController : MonoBehaviour
{
    [SerializeField] private Sprite[] _evolutionSprite = new Sprite[4];
    //[SerializeField] private Animator[] _evolutionAnimation = new Animator[3];

    private SpriteRenderer _spriteRenderer;
    //private Animator _penguinAnimator
   
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _evolutionSprite[GlobalObjectRegistry.instance.collectedPieces];
        //_penguinAnimator = GetComponent<Animator>();
    }

    // MonoBehaviour update methods
    private void Update()
    {
        //_penguinAnimator = _evolutionAnimation[GlobalObjectRegistry.instance.collectedPieces];
    }
}
