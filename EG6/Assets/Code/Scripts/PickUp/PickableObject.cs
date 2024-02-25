using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class representing a base pickable object
public class PickableObject : MonoBehaviour, IPickable
{
        public virtual void PickUp()
        {
            // Logic for picking up the object
            Debug.Log("Picking up object: " + gameObject.name);
            gameObject.SetActive(false);
        }
    
}
