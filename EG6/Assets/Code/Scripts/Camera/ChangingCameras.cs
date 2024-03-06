using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingCameras : MonoBehaviour
{
    // Block with private (or protected) _fields
    [SerializeField] private GameObject _virtualCamera;
    [SerializeField] private GameObject _virtualCameraPenguin;

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ChildMovement>() != null)
        {
            _virtualCamera.SetActive(true);
            _virtualCameraPenguin.SetActive(false);
        }
        else if(collision.GetComponent<PenguinMovement>() != null)
        {
            _virtualCamera.SetActive(false);
            _virtualCameraPenguin.SetActive(true);
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<ChildMovement>() != null)
        {
            _virtualCamera.SetActive(false);
            _virtualCameraPenguin.SetActive(false);

        }
        else if (other.GetComponent<PenguinMovement>() != null)
        {
            _virtualCamera.SetActive(false);
            _virtualCameraPenguin.SetActive(false);
        }
    }



}
