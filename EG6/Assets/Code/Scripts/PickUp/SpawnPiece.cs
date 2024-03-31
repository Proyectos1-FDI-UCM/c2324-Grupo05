using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiece : MonoBehaviour
{
    [SerializeField] GameObject _piece;
    private void Awake()
    {
        _piece.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        { 
        
            _piece.SetActive(true);
        
        }
    }
}
