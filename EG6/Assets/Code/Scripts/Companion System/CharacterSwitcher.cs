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
    private KidTestt _animatorController; //(of child)

    public bool isControllingChild = true;
    

    private void Start()
    {
        _childPlayerMovement = _childCharacter.GetComponent<ChildMovement>();
        _penguinPlayerMovement = _penguinCharacter.GetComponent<PenguinMovement>();
        _childPlayerInput = _childCharacter.GetComponent<PlayerControlInput>();
        _penguinPlayerInput = _penguinCharacter.GetComponent<PlayerControlInput>();
        _penguinNavMeshAgent = _penguinCharacter.GetComponent<NavMeshAgent>();
        _childCharacterInteraction = _childCharacter.GetComponent<CharacterInteraction>(); 
        _penguinCharacterInteraction = _penguinCharacter.GetComponent<CharacterInteraction>();
        _animatorController = _childCharacter.GetComponent<KidTestt>();
    }


    public void SwitchCharacter()
    {
        if (GlobalObjectRegistry.instance.isPenguinUnlocked == false)
        {
            return;
        }

        _childPlayerMovement.enabled = !isControllingChild;
        _childPlayerInput.enabled = !isControllingChild;
        _penguinPlayerInput.enabled = isControllingChild;
        _penguinNavMeshAgent.enabled = !isControllingChild;
        _penguinCharacterInteraction.enabled = isControllingChild;
        _childCharacterInteraction.enabled = !isControllingChild;

        _childCharacterInteraction.DiscardSelection();
        _penguinCharacterInteraction.DiscardSelection();

        if (isControllingChild)
        {
            _penguinPlayerMovement.ControllingMode = ControllingMode.PlayerControlled;
            isControllingChild = false;
             _animatorController.ActivateAnimator();
        }
        else
        {
            _penguinPlayerMovement.ControllingMode = ControllingMode.AIControlled;
            isControllingChild = true;
              _animatorController.DeactivateAnimator();
        }
    }
}
