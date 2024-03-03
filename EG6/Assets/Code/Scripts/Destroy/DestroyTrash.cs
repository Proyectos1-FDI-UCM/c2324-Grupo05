using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;


public class DestroyTrash: MonoBehaviour
{

    public  void Eliminate()
    {
        
            gameObject.SetActive(false);

    }


}

