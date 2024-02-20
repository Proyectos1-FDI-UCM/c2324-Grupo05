using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonComponent : MonoBehaviour
{
    // Block with private (or protected) _fields
    
    //type of button:
    [SerializeField] private int id;

    //reference to Combination Component:
    [SerializeField] private CombinationComponent _combComponent;

    //refence to target object:
    [SerializeField] private GameObject _target;
    

    // Block with public Properties {get; set;}

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
        //comprobar que sea el jugador quien colisione

        //Comprobar que tipo de botón es
        if(id != 0) //boton combinación
        {
            _combComponent.CombCheck(id);
        }
        else
        {
            //comprobar que componente tiene el target
            DoorComponent door = _target.GetComponent<DoorComponent>();
            if (door != null)
            {
                door.OnPressedButton();
            }
            //comprobar que sea cinta
        }
        


    }

    // Block with custom public Methods (with summary if it has complex logic)
}
