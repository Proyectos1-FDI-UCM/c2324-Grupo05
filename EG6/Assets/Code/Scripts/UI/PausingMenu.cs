using UnityEngine;
using UnityEngine.SceneManagement;

public class PausingMenu : MonoBehaviour
{
    private SavesManager _savesManager;

    private void Start()
    {
        _savesManager = FindObjectOfType<SavesManager>();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnPressedPause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Resume()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    
    public void LoadScreen()
    {

        SceneManager.LoadScene("InitialMenu");
    }

    public void Bedroom()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("BedroomTest");
    }

    public void SaveAndExit()
    {
        _savesManager.SaveGame();
        Application.Quit();
    }
}
