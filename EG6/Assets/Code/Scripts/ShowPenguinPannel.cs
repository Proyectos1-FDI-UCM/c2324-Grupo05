using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPenguinPannel : MonoBehaviour
{
    [SerializeField] GameObject _eggCanHelpPannel;
    [SerializeField] GameObject _collider;
    [SerializeField] int _waitTime=8;
    private void Start()
    {
        
        _eggCanHelpPannel.SetActive(false);
        _collider.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<ChildMovement>() != null&& GlobalObjectRegistry.instance.isEggPicked)
        {

            _collider.AddComponent<BoxCollider2D>();
            _eggCanHelpPannel.SetActive(true);
            Destroy(gameObject);
        }


    }
    

    


}
