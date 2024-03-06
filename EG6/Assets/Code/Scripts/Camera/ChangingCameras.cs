using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingCameras : MonoBehaviour
{
    // Block with private (or protected) _fields
    [SerializeField] private GameObject _virtualCamera;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ChildMovement>() != null)
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
