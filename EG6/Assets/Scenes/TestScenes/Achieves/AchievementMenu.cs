using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AchievementMenu : MonoBehaviour
{
    [SerializeField] private GameObject _achieveBadge;
    [SerializeField] private GameObject _achievement;
    [SerializeField] private GameObject _buttonBackSelect;

    //not available text
    [SerializeField] private GameObject _notAvailable;
    [SerializeField] private float _time = 4f;

    private void Start()
    {
        _buttonBackSelect.SetActive(false);
        _notAvailable.SetActive(false);
        _achieveBadge.SetActive(true);
        _achievement.SetActive(false);
    }

    public void BackToSelect()
    {
        _achieveBadge.SetActive(true);
        _achievement.SetActive(false);
        _buttonBackSelect.SetActive(false);
    }

    public void ShowAchievement()
    {
        //if achievement is unlocked, show achievement text
        _achieveBadge.SetActive(false);
        _achievement.SetActive(true);
        _buttonBackSelect.SetActive(true);
        
        //if achievement is locked
        /*
        _notAvailable.SetActive(true);
        StartCoroutine(Waittext());
        */
    }

    private IEnumerator Waittext()
    {
        Debug.Log("Entra a la corrutina");
        yield return new WaitForSecondsRealtime(_time);
        _notAvailable.SetActive(false);


    }
}
