using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequiresSctionFirst : MonoBehaviour
{
    [SerializeField] GameObject _eggCanHelpPannel;
    [SerializeField] GameObject _collider;
    private void Start()
    {
        _collider.SetActive(true);
        _eggCanHelpPannel.SetActive(false);
        
    }

    public void CkeckChidTouchedDoor()
    {
       
        _eggCanHelpPannel.SetActive(true);
        _collider.gameObject.SetActive(false);
    }

    


    

}
