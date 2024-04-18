using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCinematic : MonoBehaviour
{
    [SerializeField] GameObject _pannel;
    [SerializeField] private GameObject _finalTimeline;
   
    private void Start()
    {
        _finalTimeline.SetActive(false);
    }

    public void OnClickYes()
    { 
        _pannel.SetActive(false);
        _finalTimeline.SetActive(true);
    
    
    }
}
