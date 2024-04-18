using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCinematic : MonoBehaviour
{
    [SerializeField] GameObject _pannel;
    [SerializeField] private GameObject _finalTimeline;
    [SerializeField] private GameObject _credits;

    private void Start()
    {
        _finalTimeline.SetActive(false);
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
