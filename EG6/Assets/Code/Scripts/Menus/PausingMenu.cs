using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausingMenu : MonoBehaviour
{
    // Block with private (or protected) _fields
    [SerializeField] private GameObject _selectLevelMenu;

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom classes or structures

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
    public void SelectLevel()
    {
        _selectLevelMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
