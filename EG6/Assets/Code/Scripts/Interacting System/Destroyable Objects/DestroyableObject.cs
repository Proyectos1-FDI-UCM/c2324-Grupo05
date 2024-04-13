using NavMeshPlus.Components;
using UnityEngine;

/// <summary>
/// This class defines the destroyable objects in the game
/// And save the state of the destroyed objects in the LocalObjectHandler
/// This is generic class that can be inherited by other classes
/// </summary>
public class DestroyableObject : MonoBehaviour, IDestroyable, IInteractable
{
    [SerializeField] protected Sprite[] _statesSprite = new Sprite[3];
    [SerializeField] private GameObject _selectArrow;
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
            if (_durability <= 0)
            {
                _arrowInstance.SetActive(false);
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
}
