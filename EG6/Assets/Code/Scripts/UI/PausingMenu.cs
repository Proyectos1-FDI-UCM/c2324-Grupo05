using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PausingMenu : MonoBehaviour
{
    [SerializeField] GameObject _mainButtons;
    [SerializeField] private GameObject _buttonBackSelect;
    [SerializeField] GameObject _settings;
    private SavesManager _savesManager;

    private void Start()
    {
        _savesManager = FindObjectOfType<SavesManager>();
        _mainButtons.SetActive(true);
        _buttonBackSelect.SetActive(false);
        _settings.SetActive(false);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnPressedPause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackToSelect()
    {
        _mainButtons.SetActive(true);
        _buttonBackSelect.SetActive(false);
        _settings.SetActive(false);
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
        _savesManager.SaveGame();
        Time.timeScale = 1f;
        SceneManager.LoadScene("BedroomTest");
    }

    public void SaveAndExit()
    {
        _savesManager.SaveGame();
        Application.Quit();
    }

    public void Settings()
    {
        _mainButtons.SetActive(false);
        _buttonBackSelect.SetActive(true);
        _settings.SetActive(true);
    }
}
