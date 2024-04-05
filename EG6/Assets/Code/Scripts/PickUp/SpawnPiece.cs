using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiece : MonoBehaviour
{
    [SerializeField] GameObject _piece;
    private int _pieces;
    private void Awake()
    {
        _piece.SetActive(false);
        _pieces = PlayerPrefs.GetInt("pieza");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            if (_pieces==0)
            {
                _piece.SetActive(true);

            }
            
        
        }
    }
}
