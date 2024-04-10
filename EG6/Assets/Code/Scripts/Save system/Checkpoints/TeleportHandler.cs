using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// This class is used to teleport both the penguin and the child to the last checkpoint
/// Called when we launch or restart level
/// </summary>
public class TeleportHandler : MonoBehaviour
{
    [SerializeField] private Transform _penguin;
    [SerializeField] private Transform _child;
    [SerializeField] private Checkpoint[] _allCheckpoints;
    
    public Checkpoint[] AllCheckpoints { get => _allCheckpoints; }


    public void TeleportCharactersToLastCheckpoint(int checkpointIndex)
    {
        if (GlobalObjectRegistry.instance.isPenguinUnlocked == true)
        {
            _penguin.GetComponent<NavMeshAgent>().Warp(_allCheckpoints[checkpointIndex].transform.position);
            _child.position = _allCheckpoints[checkpointIndex].transform.position + new Vector3(0, 1, 0);
        }
        _penguin.GetComponent<NavMeshAgent>().Warp(_allCheckpoints[checkpointIndex].transform.position);
        _child.position = _allCheckpoints[checkpointIndex].transform.position + new Vector3(0, 1, 0);
    }
}
