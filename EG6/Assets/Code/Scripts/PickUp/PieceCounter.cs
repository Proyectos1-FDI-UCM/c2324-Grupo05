using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PieceCounter : MonoBehaviour, ICounter
{
    [SerializeField] private TextMeshProUGUI _pieceText;
    public int _collectedPieceCount = 0;

    //reference to instance
    private static PieceCounter _instancePiece;
    static public PieceCounter InstancePiece
    {
        get { return _instancePiece; }
    }

    private void Awake()
    {
        if (!_instancePiece)
        {
            _instancePiece = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementCount()
    {
        Debug.Log("llega");
        _collectedPieceCount ++;
        Debug.Log("Piece acquired" + _collectedPieceCount);
        _pieceText.text = "" + _collectedPieceCount;
    }
}
