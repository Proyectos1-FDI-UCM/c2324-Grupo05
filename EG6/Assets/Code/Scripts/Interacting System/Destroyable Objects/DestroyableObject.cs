using NavMeshPlus.Components;
using UnityEngine;
using System.Collections;

/// <summary>
/// This class defines the destroyable objects in the game
/// And save the state of the destroyed objects in the LocalObjectHandler
/// This is generic class that can be inherited by other classes
/// </summary>
public class DestroyableObject : MonoBehaviour, IDestroyable, IInteractable
{
    [SerializeField] protected Sprite[] _statesSprite = new Sprite[3];
    [SerializeField] private GameObject _selectArrow;
    [SerializeField] private AudioClip _onHitSound;
    [SerializeField] private AudioClip _onDestroySound;
    [SerializeField] private int _id;
    
    protected int _durability = 12;
    protected bool _isSelected = false;

    protected LocalObjectHandler _localObjectHandler;
    protected SpriteRenderer _spriteRenderer;
    protected NavMeshSurface _navMeshSurface;
    protected GameObject _arrowInstance;

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
            if (_arrowInstance == null)
            {
                _arrowInstance = Instantiate(_selectArrow, transform.position + Vector3.up * 1f, Quaternion.identity);
            }
            else
            {
                _arrowInstance.SetActive(true);
            }
        }
        else
        {
            if (_arrowInstance != null)
            {
                _arrowInstance.SetActive(false);
            }
        }
    }


    public virtual void Destroy()
    {
        AudioSource.PlayClipAtPoint(_onDestroySound, transform.position);
        gameObject.SetActive(false);
        _navMeshSurface.RemoveData();
        _navMeshSurface.BuildNavMesh();
        _localObjectHandler.DestroyedObjectsIDs.Add(ID);
    }


    public virtual void PerformInteraction(CharacterInteraction characterInteraction)
    {
        GameObject character = characterInteraction.gameObject;
        CharacterDamage characterDamage = character.GetComponent<CharacterDamage>();

        if (_durability > 0)
        {
            _durability-= characterDamage.Damage;
            UpdateSprite();
            AudioSource.PlayClipAtPoint(_onHitSound, transform.position);
        }
        else if (_durability <= 0)
        {
            _arrowInstance.SetActive(false);
            Destroy();
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


    private void UpdateSprite()
    {
        if (_durability >= 12)
        {
            _spriteRenderer.sprite = _statesSprite[0];
        }
        else if (_durability >= 6)
        {
            _spriteRenderer.sprite = _statesSprite[1];
        }
        else if (_durability >= 4)
        {
            _spriteRenderer.sprite = _statesSprite[2];
        }
    }

    protected void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        Vector3 originalPosition = transform.localPosition;
        float timer = 0.0f;
        float shakeAmount = 0.05f;

        while (timer < 0.5f)
        {
            Vector3 randomPoint = originalPosition + Random.insideUnitSphere * shakeAmount;

            transform.localPosition = randomPoint;

            timer += Time.deltaTime;

            shakeAmount *= 1 - Time.deltaTime * 1f;

            yield return null;
        }
        transform.localPosition = originalPosition;
    }
}
