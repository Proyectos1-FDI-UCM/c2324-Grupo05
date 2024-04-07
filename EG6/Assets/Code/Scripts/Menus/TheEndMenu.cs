using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEndMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BacktoInitialMenu()
    {
        SceneManager.LoadScene("InitialMenu");
    }
}
