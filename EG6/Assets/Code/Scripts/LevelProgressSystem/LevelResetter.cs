using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is used to reset the level when the player crosses the reset trigger 
/// (like water or something else that kills the player)
/// </summary>
public class LevelResetter : MonoBehaviour
{
    private LocalObjectHandler _localObjectHandler;


    private void Start()
    {
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            Debug.Log("Resetting level");
            _localObjectHandler.SaveLocalState();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

