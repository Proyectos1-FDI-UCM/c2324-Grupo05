using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{
    
    [SerializeField] private GameObject[] _timelines; // Array to store all new mechanic timelines
    [SerializeField] private GameObject _introduction;
    private int _currentTimeline = -1; // index of current timeline (-1 is no timeline)

    void Start()
    {
        // All timelines stop
        foreach (GameObject timeline in _timelines)
        {
            timeline.SetActive(false);
        }

        _introduction.SetActive(false);
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
        if(!GlobalObjectRegistry.instance.isEggPicked)  
        {
            _introduction.SetActive(true);
        }
        else
        {
            _currentTimeline = GlobalObjectRegistry.instance.collectedPieces;
            _timelines[GlobalObjectRegistry.instance.collectedPieces].SetActive(true);
        }
        
    }

    //Is called at the end of each timeline (animation event)
    public void ChangeScene()
    {
        if (!GlobalObjectRegistry.instance.isEggPicked)
        {
            _introduction.SetActive(true);
        }
        else
        {
            _timelines[_currentTimeline].SetActive(false);
        }
        
        SceneManager.LoadScene("Bedroom");
    }

}
