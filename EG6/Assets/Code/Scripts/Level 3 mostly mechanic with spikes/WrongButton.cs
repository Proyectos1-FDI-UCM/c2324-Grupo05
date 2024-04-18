using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongButton : MonoBehaviour
{
   
    [SerializeField] GameObject _platform;
    [SerializeField] GameObject _pannelcollider;
    [SerializeField] float _time=5.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            _platform.SetActive(false);
            _pannelcollider.AddComponent<BoxCollider2D>();
            StartCoroutine(Wait());
           
        }


    }

    private IEnumerator Wait()
    {
       
        yield return new WaitForSeconds(_time);
  

    }


}
