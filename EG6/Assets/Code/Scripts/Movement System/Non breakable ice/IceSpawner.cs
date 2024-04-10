using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpawner : MonoBehaviour
{
    //Ice to spawn
    [SerializeField] private GameObject _ice;

    //Time to spawn
    [SerializeField] private float _spawnTime;
    private float _currentTime;

    //Reference to transform
    private Transform _myTransform;
    private BoxCollider2D _boxCollider2D;
    private bool _spawnerBlocked;

    private void Start()
    {
        _myTransform = transform;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _spawnerBlocked = false;
    }

    // MonoBehaviour update methods
    private void Update()
    {
        _currentTime += Time.deltaTime;

        // If the spawner is not blocked and the time to spawn has passed then spawn ice
        if (_spawnerBlocked == false && _currentTime >= _spawnTime ) 
        {
            _currentTime = 0;

            //New ice
            SpawnIce();

        }
        
    }

    private void SpawnIce()
    {
        Instantiate(_ice, _myTransform.position, Quaternion.identity);
    }

    // Detect if the spawner is blocked by an object with MovableObject component
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<MovableObject>() != null)
        {
            _spawnerBlocked = true;
            Debug.Log(_spawnerBlocked);
        }
       
    }

    // Detect if the spawner is not blocked by an object with MovableObject component
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MovableObject>() != null)
        {
            _spawnerBlocked = false;
            Debug.Log(_spawnerBlocked);
        }
    }

}
