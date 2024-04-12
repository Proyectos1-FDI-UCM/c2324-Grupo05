using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DecodedPhrasesMenu : MonoBehaviour
{
    [SerializeField] private GameObject _decodeNumbers;
    [SerializeField] private GameObject[] _decodePhrases;
    [SerializeField] private GameObject _buttonBackSelect;
    [SerializeField] private GameObject _notAvailable;
    [SerializeField] private float _time = 4f;


   
    public int _pCounter;

    private void Start()
    {
        
        foreach (GameObject phrase in _decodePhrases)
        {
            phrase.SetActive(false);
        }
        _buttonBackSelect.SetActive(false);
        _notAvailable.SetActive(false);
        _decodeNumbers.SetActive(true);
    }

   

    public void BackToSelect()
    {
        _decodeNumbers.SetActive(true);
        _decodePhrases[_pCounter].SetActive(false);
        _buttonBackSelect.SetActive(false);
    }

    public void ShowEggPhrase()
    {
        if (GlobalObjectRegistry.instance.collectedPieces >= 0 && GlobalObjectRegistry.instance.isEggPicked)
        {
            _pCounter = 0;
            _decodeNumbers.SetActive(false);
            _decodePhrases[_pCounter].SetActive(true);
            _buttonBackSelect.SetActive(true);
        }
        else
        {
            _notAvailable.SetActive(true);
            StartCoroutine(Waittext());
        }
    }

    public void ShowFirstPiece()
    {
        if (GlobalObjectRegistry.instance.collectedPieces >= 1)
        {
            _pCounter = 1;
            _decodeNumbers.SetActive(false);
            _decodePhrases[_pCounter].SetActive(true);
            _buttonBackSelect.SetActive(true);
        }
        else
        {
            _notAvailable.SetActive(true);
            StartCoroutine(Waittext());
        }
    }

    public void ShowSecondPiece()
    {
        if (GlobalObjectRegistry.instance.collectedPieces >= 2)
        {
            _pCounter = 2;
            _decodeNumbers.SetActive(false);
            _decodePhrases[_pCounter].SetActive(true);
            _buttonBackSelect.SetActive(true);
        }
        else
        {
            _notAvailable.SetActive(true);
            
            StartCoroutine(Waittext());
        }
    }

    public void ShowThirdPiece()
    {
        if (GlobalObjectRegistry.instance.collectedPieces >= 3)
        {
            _pCounter = 3;
            _decodeNumbers.SetActive(false);
            _decodePhrases[_pCounter].SetActive(true);
            _buttonBackSelect.SetActive(true);
        }
        else
        {
            _notAvailable.SetActive(true);
            StartCoroutine(Waittext());
            
        }
    }

    private IEnumerator Waittext()
    {
        Debug.Log("Entra a la corrutina");
        yield return new WaitForSecondsRealtime(_time);
        _notAvailable.SetActive(false);


    }

}
