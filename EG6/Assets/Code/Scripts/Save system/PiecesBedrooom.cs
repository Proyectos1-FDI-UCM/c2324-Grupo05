using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelState = GlobalObjectRegistry.LevelState;

public class PiecesBedrooom : MonoBehaviour
{
    [SerializeField] private GameObject _NoDesbloqueado;
    [SerializeField] private float _time= 4f;

    private GlobalObjectRegistry _globalObjectRegistry;
    private LevelState _levelState;
    private RequiresSctionFirst _requiresSactionFirst;
    public AudioSource Sonido;
    

    private void Start()
    {
        _NoDesbloqueado.SetActive(false);
        _globalObjectRegistry = GlobalObjectRegistry.instance;
        _levelState = _globalObjectRegistry.GetLevelState("Map-Exterior");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null) 
        {
            Sonido.Play();

            if (GlobalObjectRegistry.instance.isEggPicked)
            {

                _levelState.CurrentCheckpointID = 0;
                _globalObjectRegistry.SaveLevelState(_levelState.PickedObjects, _levelState.OpenedDoors, _levelState.DestroyedObjects, _levelState.PressedButtons, _levelState.CurrentCheckpointID, "Map-Exterior");
                SceneManager.LoadScene("Map-Exterior");
                
               
            }
            else
            {
                _NoDesbloqueado.SetActive(true);
                StartCoroutine(Waittext());
            }
        }
    }


    private IEnumerator Waittext()
    {
        yield return new WaitForSeconds(_time);
        _NoDesbloqueado.SetActive(false);
    }
}
   
