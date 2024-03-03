using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _childCharacter;
    [SerializeField] private GameObject _penguinCharacter;

    private PlayerMovement _childPlayerMovement;
    private PlayerMovement _penguinPlayerMovement;
    private PlayerControlInput _childPlayerInput;
    private PlayerControlInput _penguinPlayerInput;
    private PenguinAI _penguinAI;
    private NavMeshAgent _penguinNavMeshAgent;

    private bool _isChildActive = true;
    


    private void Start()
    {
        _childPlayerMovement = _childCharacter.GetComponent<PlayerMovement>();
        _penguinPlayerMovement = _penguinCharacter.GetComponent<PlayerMovement>();
        _childPlayerInput = _childCharacter.GetComponent<PlayerControlInput>();
        _penguinPlayerInput = _penguinCharacter.GetComponent<PlayerControlInput>();
        _penguinAI = _penguinCharacter.GetComponent<PenguinAI>();
        _penguinNavMeshAgent = _penguinCharacter.GetComponent<NavMeshAgent>();
    }

    public void SwitchCharacter()
    {
        if (_isChildActive)
        {
            _childPlayerMovement.enabled = false;
            _childPlayerInput.enabled = false;
            _penguinPlayerMovement.enabled = true;
            _penguinPlayerInput.enabled = true;
            _penguinAI.enabled = false;
            _penguinNavMeshAgent.enabled = false;
            _isChildActive = false;
        }
        else
        {
            _childPlayerMovement.enabled = true;
            _childPlayerInput.enabled = true;
            _penguinPlayerMovement.enabled = false;
            _penguinPlayerInput.enabled = false;
            _penguinAI.enabled = true;
            _penguinNavMeshAgent.enabled = true;
            _isChildActive = true;
        }
    }


}
