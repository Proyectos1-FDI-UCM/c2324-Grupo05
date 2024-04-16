using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSubmarine : MonoBehaviour
{
    [SerializeField] GameObject _submarine;
    [SerializeField] GameObject _pannel;
    [SerializeField] GameObject _trigger;
    public void ClickTransform()
    { 
        _submarine.SetActive(true);
        _pannel.SetActive(false);
        Destroy(_trigger);
    
    }
}
