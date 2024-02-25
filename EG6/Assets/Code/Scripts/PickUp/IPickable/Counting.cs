using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counting : MonoBehaviour
{
    // Block with private (or protected) _fields
    [SerializeField] private TextMeshProUGUI _pieceText;
    [SerializeField] private TextMeshProUGUI _TrashText;
    private int _nTrash = 0;
    private int _nPiece = 0;

    // Block with public Properties {get; set;}

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom classes or structures

    // Block with custom private Methods 

    // Block with custom public Methods (with summary if it has complex logic)
    public void CounterTrash()
    {
        _nTrash++;
        Debug.Log("trash acquired" + _nTrash);
        _TrashText.text = "" + _nTrash;
    }
    public void CounterPiece()
    {
        _nPiece++;
        Debug.Log("Piece acquired" + _nPiece);
        _pieceText.text = "" + _nPiece;
    }
}
