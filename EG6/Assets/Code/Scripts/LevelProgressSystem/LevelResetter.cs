using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is used to reset the level when the player crosses the reset trigger 
/// (like water or something else that kills the player)
/// </summary>
public abstract class LevelResetter : MonoBehaviour
{
    protected LocalObjectHandler _localObjectHandler;


    private void Start()
    {
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    protected virtual void ResetLevel()
    {
        _localObjectHandler.SaveLocalState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

