using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField] private int _buttonId; 
    [SerializeField] private DoorSwitcher _doorSwitcher;
    [SerializeField] private SequenceChecker _sequenceChecker;
    private Renderer _buttonRenderer;
    
    public int ButtonId { get => _buttonId; private set => _buttonId = value; } // Incapsulated property for the id

    private void Start()
    {
        _buttonRenderer = GetComponent<Renderer>();
    }

    // When the player enters the button collider, the button press command is created and executed
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            ButtonPressCommand buttonPressCommand = new ButtonPressCommand(ButtonId, _buttonRenderer);
            buttonPressCommand.Execute();

            _sequenceChecker.AddButtonToSequence(buttonPressCommand);
            _sequenceChecker.CheckSequence();
        }
    }
}
