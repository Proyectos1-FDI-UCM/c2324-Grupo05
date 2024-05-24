using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    private Animator _KidAnimator; //(of child)

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
        _KidAnimator = _childCharacter.GetComponent<Animator>();
    }


    public void SwitchCharacter()
    {
        if (GlobalObjectRegistry.instance.isPenguinUnlocked == false || SceneManager.GetActiveScene().name == "Bedroom")
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
            _KidAnimator.enabled = false;
        }
        else
        {
            _penguinPlayerMovement.ControllingMode = ControllingMode.AIControlled;
            isControllingChild = true;
            _KidAnimator.enabled = true;
        }
    }
}
