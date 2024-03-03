using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _childCharacter;
    [SerializeField] private GameObject _penguinCharacter;

    private ChildMovement _childPlayerMovement;
    private PenguinMovement _penguinPlayerMovement;
    private PlayerControlInput _childPlayerInput;
    private PlayerControlInput _penguinPlayerInput;
    private NavMeshAgent _penguinNavMeshAgent;

    private bool _isControllingChild = true;
    


    private void Start()
    {
        _childPlayerMovement = _childCharacter.GetComponent<ChildMovement>();
        _penguinPlayerMovement = _penguinCharacter.GetComponent<PenguinMovement>();
        _childPlayerInput = _childCharacter.GetComponent<PlayerControlInput>();
        _penguinPlayerInput = _penguinCharacter.GetComponent<PlayerControlInput>();
        _penguinNavMeshAgent = _penguinCharacter.GetComponent<NavMeshAgent>();
    }

    public void SwitchCharacter()
    {
        if (_isControllingChild)
        {
            _childPlayerMovement.enabled = false;
            _childPlayerInput.enabled = false;
            _penguinPlayerInput.enabled = true;
            _penguinNavMeshAgent.enabled = false;

            _penguinPlayerMovement.MovementMode = MovementMode.PlayerControlled;
            _isControllingChild = false;
        }
        else
        {
            _childPlayerMovement.enabled = true;
            _childPlayerInput.enabled = true;
            _penguinPlayerInput.enabled = false;
            _penguinNavMeshAgent.enabled = true;
            _penguinPlayerMovement.MovementMode = MovementMode.AIControlled;
            _isControllingChild = true;
        }
    }


}
