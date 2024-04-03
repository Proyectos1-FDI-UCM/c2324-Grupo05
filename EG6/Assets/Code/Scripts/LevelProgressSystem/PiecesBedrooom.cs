using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PiecesBedrooom : MonoBehaviour
{
    private int _piece;
    [SerializeField] private GameObject _SegirJugando;
    [SerializeField] private GameObject _NoDesbloqueado;
    [SerializeField] private float _time= 4f;
    private void Start()
    {
        _piece = PlayerPrefs.GetInt("pieza");
        Debug.Log("piezas" + _piece);
        _SegirJugando.SetActive(false);
        _NoDesbloqueado.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null) 
        {

            if (_piece == 4) 
            {
                _SegirJugando.SetActive(true);
                Debug.Log("Segir Jugando?");
            }
            else
            {

                _NoDesbloqueado.SetActive(true);
                StartCoroutine(Waittext());
                Debug.Log("No desbloqueado");

            }
        
        
        }
    }
    private IEnumerator Waittext()
    {
        yield return new WaitForSeconds(_time);
        _NoDesbloqueado.SetActive(false);


    }
    private void ClickYes()
    {
        //desbloquear cinematica

    }

    private void ClickNo()
    {
        _SegirJugando.SetActive(false);

    }

}
   
