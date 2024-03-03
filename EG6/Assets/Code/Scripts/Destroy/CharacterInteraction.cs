using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
public enum TipoCharacter
{
    Kid,
    Penguin
}
public class CharacterInteraction : MonoBehaviour
{
    // Block with private (or protected) _fields

    // Block with public Properties {get; set;}
    [SerializeField] TipoCharacter _char;
    private bool _childInRange;
    private bool _penguinInRange;
    /*public bool _destroyTrash=false;
    public bool _destroyIce=false;*/
    [SerializeField] DestroyIce _ice;
    [SerializeField] DestroyTrash _trash;


    public void ReceiveInterac()
    {

        if (_childInRange)
        {
            _trash.Eliminate();
            //_destroyTrash = true;

        }
        else if (_penguinInRange)
        {
            _ice.Eliminate();
           // _destroyIce = true;


        }
        else 
        {
            // _destroyIce= false;
            //_destroyTrash= false;
        
        }

    
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((collision.gameObject.GetComponent<DestroyTrash>() != null && _char == TipoCharacter.Kid))
        {

            _childInRange = true;
            _penguinInRange =false;

        }
        else if ((collision.gameObject.GetComponent<DestroyIce>() != null && _char == TipoCharacter.Penguin))
        { 
            _penguinInRange = true;
            _childInRange = false;
        }




    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        _penguinInRange = false;
        _childInRange = false;


    }






}
