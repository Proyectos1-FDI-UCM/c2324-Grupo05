using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class Water : LevelResetter
{
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            ResetLevel();
        }
        else if (collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            PenguinMovement penguinMovement = collision.gameObject.GetComponent<PenguinMovement>();
            penguinMovement.MovementMode = MovementMode.Swimming;
            penguinMovement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            PenguinMovement penguinMovement = collision.gameObject.GetComponent<PenguinMovement>();
            penguinMovement.MovementMode = MovementMode.Walking;
            penguinMovement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
