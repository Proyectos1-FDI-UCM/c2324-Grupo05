using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class to count the trash collected
/// Needs to be attached to Empty GameObject in the scene
/// </summary>
public class TrashCounter : MonoBehaviour, ICounter
{
    [SerializeField] private TextMeshProUGUI _trashText;
    private int _collectedTrashCount = 0;

    public void IncrementCount()
    {
        _collectedTrashCount++;
        _trashText.text = "" + _collectedTrashCount;
    }
}
