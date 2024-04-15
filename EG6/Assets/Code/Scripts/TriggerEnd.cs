using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnd : MonoBehaviour
{
    public AudioSource Sonido;
    [SerializeField] private GameObject _cantGo;
    [SerializeField] private GameObject _canGo;
    [SerializeField] private float _time = 4f;
    [SerializeField] private GameObject _block;
    [SerializeField] private GameObject _eggCanHelpPannel;

    private void Start()
    {
        _cantGo.SetActive(false);
        _canGo.SetActive(false);
        _block.SetActive(false);
        _eggCanHelpPannel.SetActive(false);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null && GlobalObjectRegistry.instance.collectedPieces != 2)
        {
            StartCoroutine(WaitSeconds());
            _cantGo.SetActive(true);
            StartCoroutine(Waittext());
        }
        else if (collision.gameObject.GetComponent<ChildMovement>() != null && GlobalObjectRegistry.instance.collectedPieces == 2)
        {
            StartCoroutine(WaitSeconds());
            _block.SetActive(true);
            Sonido.Play();
            _canGo.SetActive(true);
            StartCoroutine(Waittext());
        }
       
    }

   


    private IEnumerator Waittext()
    {
        yield return new WaitForSeconds(_time);
        _cantGo.SetActive(false);
        _canGo.SetActive(false);
    }

    private IEnumerator WaitSeconds()
    {
        yield return new WaitForSecondsRealtime(2);
    }



}
