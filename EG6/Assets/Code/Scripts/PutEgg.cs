using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PutEgg : MonoBehaviour
{
    [SerializeField] GameObject _egg2;
    private void Start()
    {
        _egg2.SetActive(false);
    }
    private void OnTriggerEnter2D()
    {
        if (GlobalObjectRegistry.instance.collectedPieces == 1)
        { 
        
            _egg2.SetActive(true);
        
        }
    
    
    }
}
