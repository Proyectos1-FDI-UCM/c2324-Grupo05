using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSubmarine : MonoBehaviour
{
    [SerializeField] GameObject _submarine;
    [SerializeField] GameObject _pannel;
    [SerializeField] GameObject _trigger;
    [SerializeField] GameObject _pannel2;
    public void ClickTransform()
    { 
        _submarine.SetActive(true);
        _pannel.SetActive(false);
        Destroy(_trigger);
        _pannel2.SetActive(true);
    
    }
}
