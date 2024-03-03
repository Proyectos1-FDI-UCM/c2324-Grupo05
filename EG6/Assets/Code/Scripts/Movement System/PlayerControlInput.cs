using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerControlInput : MonoBehaviour
{
    [SerializeField] private CharacterSwitcher _characterSwitcher;

    private PlayerInput _playerInput;
    private PlayerMovement _playerMovement;
    private Vector2 _inputDirection;

    
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable() 
	{
		_playerInput.Enable();
        //_playerInput.Player.Pause.performed += ctx => _pausingMenu.OnPressedPause();
        _playerInput.Player.SwitchCharacter.performed += ctx =>  _characterSwitcher.SwitchCharacter();   
    }

    private void OnDisable() 
	{
		_playerInput.Disable();
        //_playerInput.Player.Interaction.performed -= ctx => _destroy.Interaction();
    }

    // MonoBehaviour update methods
    private void FixedUpdate()
    {
        _inputDirection = new Vector2(); 

        _inputDirection = _playerInput.Player.move.ReadValue<Vector2>();

        _playerMovement.SetInputDirection(_inputDirection.normalized);
    }

}
