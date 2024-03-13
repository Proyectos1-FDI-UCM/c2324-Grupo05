using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPenguin : MonoBehaviour
{
    //referencia al switcher
    [SerializeField] private CharacterSwitcher _switcher;
    [SerializeField] private GameObject _block;


    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    // MonoBehaviour update methods
    private void Update()
    {
        if (!_switcher._isControllingChild)
        {
            _block.SetActive(true);
        }
        else
        {
            _block.SetActive(false);
        }
    }

    // Block with custom private Methods

    

    // Block with custom public Methods (with summary if it has complex logic)
}
