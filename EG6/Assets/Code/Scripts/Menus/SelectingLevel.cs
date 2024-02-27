using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectingLevel : MonoBehaviour
{
    // Block with private (or protected) _fields
    [SerializeField] private Teleporting _teleport;

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        gameObject.SetActive(true);
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom classes or structures

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
    public void Level0()
    {
        _teleport.Teleport(0);
        gameObject.SetActive(false);
    }
    public void Level1()
    {
        _teleport.Teleport(1);
        gameObject.SetActive(false);
    }
    public void Level2()
    {
        _teleport.Teleport(2);
        gameObject.SetActive(false);
    }
    public void Level3()
    {
        _teleport.Teleport(3);
        gameObject.SetActive(false);
    }





}
