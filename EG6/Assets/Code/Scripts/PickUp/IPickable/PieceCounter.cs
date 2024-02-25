using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PieceCounter : MonoBehaviour, ICounter
{
    [SerializeField] private TextMeshProUGUI _pieceText;
    private int _collectedPieceCount = 0;

    public void IncrementCount()
    {
        _collectedPieceCount ++;
        Debug.Log("Piece acquired" + _collectedPieceCount);
        _pieceText.text = "" + _collectedPieceCount;
    }
}
