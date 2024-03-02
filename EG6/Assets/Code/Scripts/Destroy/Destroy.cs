using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using static UnityEditor.Progress;
public enum TipoItem
{
    Hielo,
    Basura
}

public class Destroy: MonoBehaviour
{
  
    [SerializeField]TipoItem item;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //needs to check if there is a collision despite who is the character
        //To see if player is in range and the botton is pressed
       
            Debug.Log("collision");
            if ((collision.gameObject.GetComponent<PlayerMovement>() != null && item == TipoItem.Basura)
                ||( collision.gameObject.GetComponent<PenguinAI>() != null && item == TipoItem.Hielo))
            {
                Debug.Log("destroyed");
                gameObject.SetActive(false);
               

            }

        
     

    }



}

