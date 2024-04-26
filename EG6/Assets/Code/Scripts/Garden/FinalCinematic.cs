using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FinalCinematic : MonoBehaviour
{
    [SerializeField] GameObject _pannel;
    [SerializeField] private GameObject _finalTimeline;
    [SerializeField] private GameObject _credits;
    [SerializeField] private UnityEngine.UI.Button _yesButton;

    private void Start()
    {
        _finalTimeline.SetActive(false);
        if (Input.GetJoystickNames().Length != 0)
        {
            EventSystem.current.SetSelectedGameObject(_yesButton.gameObject);
        }
    }

    public void OnClickYes()
    { 
        //_pannel.SetActive(false);
        _finalTimeline.SetActive(true);


    }

    public void EndTimeline()
    {
        _finalTimeline.SetActive(false);
        _credits.SetActive(true);
    }

    public void EndCredits()
    {
        SceneManager.LoadScene("InitialMenu");
    }

}
