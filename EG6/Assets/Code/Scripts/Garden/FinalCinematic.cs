using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCinematic : MonoBehaviour
{
    [SerializeField] GameObject _pannel;
    public void OnClickYes()
    { 
        _pannel.SetActive(false);
        //put cinematic
    
    
    }
}
