using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceRespawnAndPlayer : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _tpplayer;
    [SerializeField] GameObject _pieza;
    [SerializeField] GameObject _tppieza;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovableObject>() != null)
        {

            _player.transform.position = _tpplayer.transform.position;
            _pieza.transform.position = _tppieza.transform.position;



        }
    }
}
