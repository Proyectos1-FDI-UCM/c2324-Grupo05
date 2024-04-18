using UnityEngine;
using UnityEngine.SceneManagement;

public class PausingMenu : MonoBehaviour
{

    private void Start()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Update()
    {
        
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
}
