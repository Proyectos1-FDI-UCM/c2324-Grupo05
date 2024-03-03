using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;
public enum TipoItem
{
    Hielo,
    Basura
}

public class Destroy: MonoBehaviour
{
  
    [SerializeField]TipoItem item;
    public bool _childInRange;
    private bool _penguinInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            Debug.Log("Child in range");
            _childInRange = true;
            _penguinInRange = false;
        }
        else if(collision.gameObject.GetComponent<AIMovement>() != null)
        {
            Debug.Log("Penguin in range");
            _childInRange = false;
            _penguinInRange = true;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _childInRange =false;
        _penguinInRange = false;
    }

    private void Eliminate()
    {
        if ((_childInRange && item == TipoItem.Basura)
                || (_penguinInRange && item == TipoItem.Hielo))
        {
            Destroy(gameObject);
            gameObject.SetActive(false);


        }
    }

    public void Interaction()
    {
        Debug.Log("interaction");
        if (_childInRange || _penguinInRange)
        {
            Debug.Log("deberia");
            Eliminate();
        }
    }

}

