using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalObjectRegistry;
using UnityEngine.SceneManagement;

public class ShowEggBedroom : MonoBehaviour
{
    [SerializeField] GameObject _egg;
    [SerializeField] GameObject _pannelEgg;
    [SerializeField] GameObject _collider;


    private void Start()
    {
      
        _egg.SetActive(false);
       
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null&& GlobalObjectRegistry.instance.isEggPicked)
        {
            
            _egg.SetActive(true);
            _pannelEgg.SetActive(false);
           _collider.SetActive(false);
            
        }
    }
   

}
