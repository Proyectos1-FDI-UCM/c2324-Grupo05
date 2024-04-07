using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candy : MonoBehaviour
{
    private int _piece;
    [SerializeField] private GameObject _candy;
    [SerializeField] private float _time = 4f;

    private void Start()
    {
       
        _candy.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null|| collision.gameObject.GetComponent<PenguinMovement>() != null)
        {


                _candy.SetActive(true);
            StartCoroutine(Waittext());

        }
    }
    private IEnumerator Waittext()
    {
        yield return new WaitForSeconds(_time);
        _candy.SetActive(false);


    }


}
