using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerControlInput : MonoBehaviour
{
    private CharacterSwitcher _characterSwitcher;

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
        _characterSwitcher = FindAnyObjectByType<CharacterSwitcher>();
    }

    private void OnEnable() 
	{
		_playerInput.Enable();
        _playerInput.Player.SwitchCharacter.performed += ctx =>  _characterSwitcher.SwitchCharacter();   
    }

    private void OnDisable() 
	{
		_playerInput.Disable();
    }

    private void FixedUpdate()
    {
        _inputDirection = new Vector2(); 

        _inputDirection = _playerInput.Player.move.ReadValue<Vector2>();

        _playerMovement.SetInputDirection(_inputDirection.normalized);
    }

}
