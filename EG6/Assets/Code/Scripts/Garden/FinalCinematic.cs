using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FinalCinematic : MonoBehaviour
{
    [SerializeField] GameObject _pannel;
    [SerializeField] private GameObject _finalTimeline;
    [SerializeField] private GameObject _credits;
    [SerializeField] private UnityEngine.UI.Button _yesButton;
    [SerializeField] private AudioSource _mapExteriorSource;
    [SerializeField] private CharacterSwitcher _switcher;
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
        GlobalObjectRegistry.instance.isPenguinUnlocked = false;
        if (_switcher.isControllingChild)
        {

            _mapExteriorSource.mute = true;
            _finalTimeline.SetActive(true);
        }
        else 
        {
            _pannel.SetActive(true);
        }
       


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
