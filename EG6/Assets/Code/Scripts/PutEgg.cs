using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PutEgg : MonoBehaviour
{
    [SerializeField]private PickPenguin _pickpen;
    
    private void OnTriggerEnter2D()
    {
        if (GlobalObjectRegistry.instance.collectedPieces == 1)
        {

            _pickpen.PutEgg();
            Destroy(gameObject);
        }
    
    
    }
}
