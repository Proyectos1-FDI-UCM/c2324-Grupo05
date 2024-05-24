using System.Collections.Generic;
using UnityEngine;
using LevelState = GlobalObjectRegistry.LevelState;

/// <summary>
/// Stores information about all achievements in the game and unlocks them based on certain conditions using data from the GlobalObjectRegistry.
/// </summary>
public class AchievementCollector : MonoBehaviour
{
    private List<Achievement> _achievements;
    private GlobalObjectRegistry _globalObjectRegistry;

    public List<Achievement> Achievements { get => _achievements;}
    //public GameObject achievementUnlocked;
    private void Start()
    {
        _globalObjectRegistry = GlobalObjectRegistry.instance;
        //achievementUnlocked.SetActive(false);

        _achievements = new List<Achievement>
        {
            new Achievement
            ("Not Alone", "Description: You found yourself a new friend!"),
            new Achievement
            ("Proud Greenpeace", "Description: Greenpeace loves you and admires you"),
            new Achievement
            ("Timbers!", "Description: It's goin' down, I'm yellin' timber"),
            new Achievement
            ("What about light?", "Description: All is darkness and I am darkness"),
            new Achievement
            ("The last of us", "Description: All pieces collected"),
            new Achievement
            ("Safe!", "Description: All trash collected"),
            new Achievement
            ("What about light?", "Unlock level-3"),
        };

        UnlockAchievementsByConditions();
    }

    private void UnlockAchievement(string achievementName)
    {
        foreach (Achievement achievement in _achievements)
        {
            if (achievement.Name == achievementName)
            {
                achievement.IsUnlocked = true;
            }
        }
    }

    private void UnlockAchievementsByConditions()
    {
        if (_globalObjectRegistry.isEggPicked)
        {
            UnlockAchievement("Not Alone");
        }

        if (_globalObjectRegistry.collectedTrash >= 10)
        {
            UnlockAchievement("Proud Greenpeace");
        }

        int destroyedObjects = 0;
        foreach (LevelState levelState in _globalObjectRegistry.LevelStates)
        {
            destroyedObjects += levelState.DestroyedObjects.Count;
        }

        if (destroyedObjects >= 10)
        {
            UnlockAchievement("Timbers!");
        }
        
        if (_globalObjectRegistry.collectedPieces == 3)
        {
            UnlockAchievement("The last of us");
        }

        if(_globalObjectRegistry.collectedTrash == 68)
        {
            UnlockAchievement("Safe!");
        }

        if (_globalObjectRegistry.GetLevelState("Level3").CurrentCheckpointID >= 2)
        {
            UnlockAchievement("What about light?");
        }
    }
}
