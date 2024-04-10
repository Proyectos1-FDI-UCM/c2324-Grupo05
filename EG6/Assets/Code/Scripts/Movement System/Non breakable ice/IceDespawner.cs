using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceDespawner : MonoBehaviour
{
    //[SerializeField] private GameObject _ice;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovableObject>()!= null)
        {
            Destroy(collision.gameObject);
        }
    }
}
