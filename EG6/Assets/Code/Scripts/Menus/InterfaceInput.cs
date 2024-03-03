using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InterfaceInput : MonoBehaviour
{
    private PlayerInput.InterfaceActions _interfaceInput;
    
    [SerializeField] private PausingMenu _pausingMenu;
    [SerializeField] private Destroy _destroy;
    
    private void Awake()
    {
        PlayerInput playerInput = new PlayerInput();
        _interfaceInput = playerInput.Interface;
    }


    private void OnEnable() 
	{
		_interfaceInput.Enable();
        _interfaceInput.Pause.performed += ctx => _pausingMenu.OnPressedPause(); 
    }

    private void OnDisable() 
	{
		_interfaceInput.Disable();
    }

}
