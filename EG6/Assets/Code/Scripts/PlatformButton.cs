using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    [SerializeField] private GameObject _platformCollider;
   

    private void Start()
    {
        _platformCollider.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _platformCollider.SetActive(true);
    }
}
