using UnityEngine;

public class IceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _ice;

    [SerializeField] private float _spawnTime;
    private float _currentTime;

    private Transform _myTransform;
    private bool _spawnerBlocked;


    private void Start()
    {
        _myTransform = transform;
        _spawnerBlocked = false;
    }

    
    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_spawnerBlocked == false && _currentTime >= _spawnTime ) 
        {
            _currentTime = 0;
            SpawnIce();
        }
    }
    

    private void SpawnIce()
    {
        Instantiate(_ice, _myTransform.position, Quaternion.identity);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<MovableObject>() != null)
        {
            _spawnerBlocked = true;
            Debug.Log(_spawnerBlocked);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MovableObject>() != null)
        {
            _spawnerBlocked = false;
            Debug.Log(_spawnerBlocked);
        }
    }
}
