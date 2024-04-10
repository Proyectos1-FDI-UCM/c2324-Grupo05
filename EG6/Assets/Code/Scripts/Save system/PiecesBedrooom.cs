using System.Collections;
using UnityEngine;

public class PiecesBedrooom : MonoBehaviour
{
    [SerializeField] private GameObject _SegirJugando;
    [SerializeField] private GameObject _NoDesbloqueado;
    [SerializeField] private float _time= 4f;
    public AudioSource Sonido;
   

    private void Start()
    {
        _SegirJugando.SetActive(false);
        _NoDesbloqueado.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null) 
        {
            Sonido.Play();
            if (GlobalObjectRegistry.instance.collectedPieces == 2) 
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
}
   
