
   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAllPieces : MonoBehaviour
{
    [SerializeField] GameObject _bottonExit;

    [SerializeField] int _numpieces = 2; //3 for endgame, 2 test
    private void Start()
    {

        _bottonExit.SetActive(false);
        if (GlobalObjectRegistry.instance.collectedPieces == _numpieces)
        {

            _bottonExit.SetActive(true);

        }
    }

    

}

