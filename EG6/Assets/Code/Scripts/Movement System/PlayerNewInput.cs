using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerNewInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Vector2 _inputDirection;
    private PlayerInput _playerInput;
    [SerializeField] PausingMenu _pausingMenu;

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable() 
	{
		_playerInput.Enable();
        _playerInput.Player.Pause.performed += ctx => _pausingMenu.OnPressedPause();
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnDisable() 
	{
		_playerInput.Disable();
	}

    // MonoBehaviour update methods
    private void FixedUpdate()
    {
        _inputDirection = new Vector2(); //(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _inputDirection = _playerInput.Player.move.ReadValue<Vector2>();

        _playerMovement.SetInputDirection(_inputDirection.normalized);
    }

    // Block with custom classes or structures

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
}
