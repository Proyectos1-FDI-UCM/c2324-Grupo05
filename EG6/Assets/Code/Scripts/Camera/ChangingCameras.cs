using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingCameras : MonoBehaviour
{
    // Block with private (or protected) _fields
    [SerializeField] private GameObject _virtualCamera;
    [SerializeField] private GameObject _target;
    [SerializeField] private Transform _child;
    [SerializeField] private Transform _penguin;
    [SerializeField] private CharacterSwitcher _switcher;


    private void Start()
    {
        _virtualCamera.SetActive(false);
    }

    private void Update()
    {
        //Check whether the child or the penguin is moving
        //Camera should follow the one that is bein controlled at that moment
        
        if(_switcher._isControllingChild)
        {
            _target.transform.position = _child.position;
        }
        else
        {
            _target.transform.position = _penguin.position;
        }
        

        
    }

    /*
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (((collision.GetComponent<ChildMovement>() != null) && _switcher._isControllingChild)
            || ((collision.GetComponent<PenguinMovement>() != null) && !_switcher._isControllingChild))
        {
            Debug.Log("Entra");
            _virtualCamera.SetActive(true);
            
        }
        
    }
    */

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (((collision.GetComponent<ChildMovement>() != null) && _switcher._isControllingChild)
            || ((collision.GetComponent<PenguinMovement>() != null) && !_switcher._isControllingChild))
        {
            Debug.Log("Está");
            _virtualCamera.SetActive(true);

        }
        else
        {
            Debug.Log("No Está");
            _virtualCamera.SetActive(false);
        }
    }

    /*
    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (((other.GetComponent<ChildMovement>() != null) && _switcher._isControllingChild)
            || ((other.GetComponent<PenguinMovement>() != null) && !_switcher._isControllingChild))
        {
            Debug.Log("Sale");
            _virtualCamera.SetActive(false);

        }

    }
    */


}
