using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counting : MonoBehaviour
{
    // Block with private (or protected) _fields
    private int _nTrash;
    private int _nPiece;

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
        Debug.Log("trash acquired"+_nTrash);
    }
    public void CounterPiece()
    {
        _nPiece++;
        Debug.Log("Piece acquired" + _nPiece);
    }
}
