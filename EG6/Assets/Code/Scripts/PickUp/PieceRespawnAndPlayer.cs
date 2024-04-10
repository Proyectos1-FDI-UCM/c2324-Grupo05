using UnityEngine;

public class PieceRespawnAndPlayer : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _tpplayer;
    [SerializeField] GameObject _pieza;
    [SerializeField] GameObject _tppieza;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Piece>() != null)
        {
            _player.transform.position = _tpplayer.transform.position;
            _pieza.transform.position = _tppieza.transform.position;
            _pieza.GetComponent<MovableObject>().enabled = false;
        }
    }
}
