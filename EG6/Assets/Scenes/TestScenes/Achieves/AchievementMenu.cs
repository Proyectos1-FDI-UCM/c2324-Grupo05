using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AchievementMenu : MonoBehaviour
{
    [SerializeField] private GameObject _achieveBadge;
    [SerializeField] private TextMeshProUGUI _achievementText;
    [SerializeField] private GameObject _buttonBackSelect;
    public List<Achievement> Achievements;
    private AchievementCollector _achievementCollector;

    //not available text
    [SerializeField] private GameObject _notAvailable;
    [SerializeField] private float _time = 4f;

    private void Start()
    {
        _achievementCollector = GetComponent<AchievementCollector>();
        _buttonBackSelect.SetActive(false);
        _notAvailable.SetActive(false);
        _achieveBadge.SetActive(true);
        _achievementText.enabled = false;
    }

    public void BackToSelect()
    {
        _achieveBadge.SetActive(true);
        _achievementText.enabled = false;
        _buttonBackSelect.SetActive(false);
    }

    public void ShowAchievement(string achievementName)
    {
        
        foreach (Achievement achievement in _achievementCollector.Achievements)
        {
            if (achievement.Name == achievementName)
            {
                //if achievement is unlocked, show achievement text
                if (achievement.IsUnlocked == true)
                {
                    _achieveBadge.SetActive(false);
                    _achievementText.text = achievement.Name;
                    _achievementText.enabled = true;
                    _buttonBackSelect.SetActive(true);
                }
                else
                {
                    //if achievement is locked
                    _notAvailable.SetActive(true);
                    StartCoroutine(Waittext());
                    
                }
            }
        }

        
    }

    private IEnumerator Waittext()
    {
        Debug.Log("Entra a la corrutina");
        yield return new WaitForSecondsRealtime(_time);
        _notAvailable.SetActive(false);


    }
}
