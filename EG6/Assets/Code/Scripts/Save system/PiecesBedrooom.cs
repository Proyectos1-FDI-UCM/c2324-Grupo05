using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PiecesBedrooom : MonoBehaviour
{
    [SerializeField] private GameObject _SegirJugando;
    [SerializeField] private GameObject _NoDesbloqueado;
    [SerializeField] private Transform _gardenDoor;
    [SerializeField] private Transform _child;
    [SerializeField] private Transform _penguin;
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

            if (GlobalObjectRegistry.instance.isEggPicked)
            {

                SceneManager.LoadScene("Map-Exterior");

               /* //child can go to garden
                _child.position = _gardenDoor.position;

                if (GlobalObjectRegistry.instance.isPenguinUnlocked)
                {
                    //penguin follows child after piece 1
                    _penguin.position = _gardenDoor.position;
                }*/
            }
            else
            {
                _NoDesbloqueado.SetActive(true);
                StartCoroutine(Waittext());
                Debug.Log("No desbloqueado");

            }

            if (GlobalObjectRegistry.instance.collectedPieces == 3)
            {
                _SegirJugando.SetActive(true);
                Debug.Log("Segir Jugando?");
            }
           
            
        }
    }


    private IEnumerator Waittext()
    {
        yield return new WaitForSeconds(_time);
        _NoDesbloqueado.SetActive(false);
    }
}
   
