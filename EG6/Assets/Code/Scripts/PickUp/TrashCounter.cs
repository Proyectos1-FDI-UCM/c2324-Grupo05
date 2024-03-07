using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
