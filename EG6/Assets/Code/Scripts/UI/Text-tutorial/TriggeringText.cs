using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringText : MonoBehaviour
{

    [SerializeField] private GameObject _panel;
    [SerializeField] private float _waitTime;


    private void Start()
    {
        _panel.SetActive(false);
       
           
    }

    // Block with custom private Methods 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {

            StartCoroutine(Texting());
          
        }


    }

    private IEnumerator Texting()
    {
        _panel.SetActive(true);
        yield return new WaitForSeconds(_waitTime);
        Destroy(_panel);
        Destroy(gameObject);
    

    }

 
  
}
