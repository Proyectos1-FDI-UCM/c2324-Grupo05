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
    private PlayerNewInput _playernewinput;
    private PenguinAI _penguinAI;
    private bool _inputEnabled;
    [SerializeField] PausingMenu _pausingMenu;

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playernewinput = FindObjectOfType<PlayerNewInput>();
    }

    private void OnEnable() 
	{
		_playerInput.Enable();
        _playerInput.Player.Pause.performed += ctx => _pausingMenu.OnPressedPause();
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _penguinAI = GetComponent<PenguinAI>();
    }

    private void OnDisable() 
	{
		_playerInput.Disable();
	}

    // MonoBehaviour update methods
    private void FixedUpdate()
    {
        _inputDirection = new Vector2(); 

        _inputDirection = _playerInput.Player.move.ReadValue<Vector2>();

        _playerMovement.SetInputDirection(_inputDirection.normalized);
    }

    // Block with custom classes or structures

    // Block with custom private Methods 

    private void OnChangecharacter()
    {
        Debug.Log("Change character");
        if (_inputEnabled)
        {
            this._playernewinput.enabled = false;
           // _playerInput.Player.move.Disable();
            _inputEnabled = false;
        }
        else
        {
            
            this._playernewinput.enabled = true;
            //_playerInput.Player.move.Enable();
            _inputEnabled = true;
        }
    }

    // Block with custom public Methods (with summary if it has complex logic)
}
