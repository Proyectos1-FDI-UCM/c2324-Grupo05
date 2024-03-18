using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHandler : MonoBehaviour
{
    [SerializeField] private Transform _penguin;
    [SerializeField] private Transform _child;
    [SerializeField] private Checkpoint[] _allCheckpoints;


    public void TeleportCharactersToLastCheckpoint(int checkpointIndex)
    {
        _penguin.position = _allCheckpoints[checkpointIndex - 1].transform.position;
        _child.position = _allCheckpoints[checkpointIndex - 1].transform.position;
    }
}
