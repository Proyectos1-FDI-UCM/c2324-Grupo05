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

    private void Start()
    {
        _myTransform = transform;
    }

    // MonoBehaviour update methods
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _spawnTime)
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
    
}
