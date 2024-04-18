using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasdPannel : MonoBehaviour
{
    [SerializeField] GameObject _pannel;

    private void Start()
    {
           
        if (GlobalObjectRegistry.instance.isEggPicked)
        {
            _pannel.SetActive(false);

        }
        
    }


    public void OnClickYes()
    { 
    
        _pannel.SetActive(false);
        
    }
}
