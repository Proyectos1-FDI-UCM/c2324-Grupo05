using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This class is used to switch between the characters in the game.
/// Recieves input from the player and switches the control between the characters.
/// When the player is controlling the child, the penguin is controlled by the AI.
/// </summary>
public class CharacterSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _childCharacter;
    [SerializeField] private GameObject _penguinCharacter;

    private ChildMovement _childPlayerMovement;
    private PenguinMovement _penguinPlayerMovement;
    private PlayerControlInput _childPlayerInput;
    private PlayerControlInput _penguinPlayerInput;
    private NavMeshAgent _penguinNavMeshAgent;
    private CharacterInteraction _childCharacterInteraction;
    private CharacterInteraction _penguinCharacterInteraction;

    public bool _isControllingChild = true;
    
    private void Start()
    {
        _childPlayerMovement = _childCharacter.GetComponent<ChildMovement>();
        _penguinPlayerMovement = _penguinCharacter.GetComponent<PenguinMovement>();
        _childPlayerInput = _childCharacter.GetComponent<PlayerControlInput>();
        _penguinPlayerInput = _penguinCharacter.GetComponent<PlayerControlInput>();
        _penguinNavMeshAgent = _penguinCharacter.GetComponent<NavMeshAgent>();
        _childCharacterInteraction = _childCharacter.GetComponent<CharacterInteraction>(); 
        _penguinCharacterInteraction = _penguinCharacter.GetComponent<CharacterInteraction>();
    }

    public void SwitchCharacter()
    {
        if (GlobalObjectRegistry.instance.isPenguinUnlocked == false)
        {
            return;
        }

        _childPlayerMovement.enabled = !_isControllingChild;
        _childPlayerInput.enabled = !_isControllingChild;
        _penguinPlayerInput.enabled = _isControllingChild;
        _penguinNavMeshAgent.enabled = !_isControllingChild;
        _penguinCharacterInteraction.enabled = _isControllingChild;
        _childCharacterInteraction.enabled = !_isControllingChild;

        _childCharacterInteraction.DiscardSelection();
        _penguinCharacterInteraction.DiscardSelection();

        if (_isControllingChild)
        {
            _penguinPlayerMovement.ControllingMode = ControllingMode.PlayerControlled;
            _isControllingChild = false;
        }
        else
        {
            _penguinPlayerMovement.ControllingMode = ControllingMode.AIControlled;
            _isControllingChild = true;
        }
    }


}
