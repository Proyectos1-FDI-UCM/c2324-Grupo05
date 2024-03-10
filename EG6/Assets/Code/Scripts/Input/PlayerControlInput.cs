using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class is used to handle the input for the player (character) actions.
/// </summary>
public class PlayerControlInput : MonoBehaviour
{
    private CharacterSwitcher _characterSwitcher;

    private PlayerInput _playerInput;
    private MovableObject _playerMovement;
    private CharacterInteraction _characterInteraction;
    private Vector2 _inputDirection;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Start()
    {
        _playerMovement = GetComponent<MovableObject>();
        _characterSwitcher = FindAnyObjectByType<CharacterSwitcher>();
        _characterInteraction = GetComponent<CharacterInteraction>();
    }

    private void OnEnable() 
	{
		_playerInput.Enable();
        _playerInput.Player.SwitchCharacter.performed += ctx =>  _characterSwitcher.SwitchCharacter();  
        _playerInput.Player.Interaction.performed += ctx => _characterInteraction.Interact();
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
