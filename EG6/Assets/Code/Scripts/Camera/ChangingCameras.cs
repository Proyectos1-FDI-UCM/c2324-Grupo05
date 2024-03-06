using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingCameras : MonoBehaviour
{
    // Block with private (or protected) _fields
    [SerializeField] private GameObject _virtualCamera;

    private void Start()
    {
        _virtualCamera.SetActive(false);
    }


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ChildMovement>())
        {
            Debug.Log("Entra");
            _virtualCamera.SetActive(true);
            
        }
        
    }
    

    
    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<ChildMovement>())
        {
            Debug.Log("Sale");
            _virtualCamera.SetActive(false);

        }

    }
    


}
