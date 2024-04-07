using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
    protected LocalObjectHandler _localObjectHandler;
    private void Start()
    {
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
    }

    public void ResetLevel()
    {
        _localObjectHandler.SaveLocalState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
