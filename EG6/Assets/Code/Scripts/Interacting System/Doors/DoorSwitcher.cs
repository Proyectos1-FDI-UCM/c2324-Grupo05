using NavMeshPlus.Components;
using UnityEngine;

/// <summary>
/// This class is used to switch the state of the door (opened or closed)
/// And save the state of the door in the LocalObjectHandler
/// </summary>
public class DoorSwitcher : MonoBehaviour
{
    [SerializeField] private int _id;
    private bool _isDoorOpen = false;

    protected NavMeshSurface _navMeshSurface;
    private LocalObjectHandler _localObjectHandler;
    private GameObject _door;
    private AudioManager _audioManager;

    public int ID { get => _id;}

    private void Start()
    {
        _door = gameObject;
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
        _isDoorOpen = _localObjectHandler.OpenedDoorsIDs.Contains(ID);
        _navMeshSurface = FindObjectOfType<NavMeshSurface>();
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void UpdateDoorState()
    {
        if (_isDoorOpen)
        {
            _door.SetActive(false);
            _navMeshSurface.RemoveData();
            _navMeshSurface.BuildNavMesh();
            _localObjectHandler.OpenedDoorsIDs.Add(ID);
            
        }
        else
        {
            _door.SetActive(true);
        }
    }


    public void SetDoorState(bool state)
    {
        if (_isDoorOpen == state)
        {
            return;
        }

        _isDoorOpen = state;
        UpdateDoorState();

        _audioManager.PlaySFX(_audioManager._doorOpened);
        /*
        AudioClip onPressedSound = Resources.Load<AudioClip>("Audio/Buttons/doorOpened");
        AudioSource.PlayClipAtPoint(onPressedSound, transform.position);
        */
    }
}
