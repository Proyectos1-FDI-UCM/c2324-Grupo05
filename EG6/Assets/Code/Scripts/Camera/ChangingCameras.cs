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

        if (_switcher._isControllingChild)
        {
            _target.transform.position = _child.position;
            Debug.Log("niño");
        }
        else
        {
            _target.transform.position = _penguin.position;
            Debug.Log("pinguino");
        }

    }


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hellou");
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            
            _virtualCamera.SetActive(true);
            
        }
        
    }
    

    
    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<ChildMovement>() != null)
        {
            
            _virtualCamera.SetActive(false);

        }

    }
    


}
