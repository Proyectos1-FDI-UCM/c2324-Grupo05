using UnityEngine;
using TMPro;

/// <summary>
/// Class to count the pieces collected
/// </summary>
public class PieceCounter : MonoBehaviour, ICounter
{
    [SerializeField] private TextMeshProUGUI _pieceText;
    public int _collectedPieceCount = 0;

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
        _collectedPieceCount ++;
        _pieceText.text = "" + _collectedPieceCount;
    }
}
