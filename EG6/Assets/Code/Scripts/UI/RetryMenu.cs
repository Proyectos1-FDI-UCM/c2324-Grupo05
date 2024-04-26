using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
    [Header("First Selected Object")]
    [SerializeField] private GameObject _firstSelectedObject;

    protected LocalObjectHandler _localObjectHandler;
    private void Start()
    {
        gameObject.SetActive(false);
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();

         if (Input.GetJoystickNames().Length == 0)
        {
            return;
        }
        if (_firstSelectedObject != null)
        {
            EventSystem.current.SetSelectedGameObject(_firstSelectedObject);
        }
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        _localObjectHandler.SaveLocalState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
