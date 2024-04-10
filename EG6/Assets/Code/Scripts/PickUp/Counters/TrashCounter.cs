using UnityEngine;
using TMPro;

/// <summary>
/// Class to count the trash collected
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
