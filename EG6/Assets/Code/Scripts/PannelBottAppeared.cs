using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelBottAppeared : MonoBehaviour
{
    [SerializeField] int _pieces = 2;
    [SerializeField] GameObject _pannel;
    public AudioSource Sonido;

    private void Start()
    {

        _pannel.SetActive(false);
        if (GlobalObjectRegistry.instance.collectedPieces == _pieces)
        {
            Sonido.Play();
            _pannel.SetActive(true);


        }
    }



}
