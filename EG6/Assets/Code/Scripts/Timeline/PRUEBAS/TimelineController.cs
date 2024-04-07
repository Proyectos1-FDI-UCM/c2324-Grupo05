using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    //reference to saved file
    //private int _piece;
    [SerializeField] private GameObject[] _timelines; // Array to store all timelines
    private int _currentTimeline = -1; // index of current timeline (-1 is no timeline)

    void Start()
    {
        // All timelines stop
        foreach (GameObject timeline in _timelines)
        {
            timeline.SetActive(false);
        }

        //_piece = PlayerPrefs.GetInt("pieza");
        StartTimeline();

    }

    
    public void StartTimeline()
    {
        // If there's a timeline playing we stop it
        if (_currentTimeline != -1)
        {
            _timelines[_currentTimeline].SetActive(false);
        }

        // Start new timeline
        _currentTimeline = GlobalObjectRegistry.instance.collectedPieces;
        _timelines[GlobalObjectRegistry.instance.collectedPieces].SetActive(true);
    }

    //Is called at the end of each timeline (animation event)
    public void ChangeScene()
    {
        _timelines[_currentTimeline].SetActive(false);
        SceneManager.LoadScene("BedroomTest");
    }

}
