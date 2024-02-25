using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpComponent : MonoBehaviour
{
    // Block with private (or protected) _fields

    // Block with public Properties {get; set;}

    //reference to ContadorManager
    [SerializeField] private ContadorManager _contador;

    // Block with MonoBehaviour life-cycle methods (ONLY mono-functions)
    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    // MonoBehaviour update methods
    private void Update()
    {
        
    }

    // Block with custom classes or structures

    // Block with custom private Methods 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //comprobar que sea el jugador

        //comprobar que tipo de recogible es:
        
        if(gameObject.GetComponent<PiezaComponent>())
        {
            Debug.Log("Es una pieza");
            _contador.PiezaContador();
        }
        else //no es una pieza, por lo que es basura recogible
        {
            _contador.TrashContador();
        }

        //Destruir objeto recogido
        Destroy(gameObject);
    }

    // Block with custom public Methods (with summary if it has complex logic)
}
