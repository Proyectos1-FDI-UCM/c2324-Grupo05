using UnityEngine;

/// <summary>
/// This class is used to handle the input for the interface actions.
/// </summary>
public class InterfaceInput : MonoBehaviour
{
    private PlayerInput.InterfaceActions _interfaceInput;
    
    [SerializeField] private PausingMenu _pausingMenu;
    [SerializeField] private CharacterInteraction _characterInteraction;
    

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
