using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelting : MonoBehaviour
{
    [SerializeField] GameObject _meltingIce;

    private void Start()
    {
        _meltingIce.SetActive(false);
    }



    private void ShowIce()
    {
        if (GlobalObjectRegistry.instance.collectedPieces == 2)
        {
            _meltingIce.SetActive(true);
            
        }

    }




}
