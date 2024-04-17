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

    private void Start()
    {
        _globalObjectRegistry = GlobalObjectRegistry.instance;

        _achievements = new List<Achievement>
        {
            new Achievement
            ("A new friend!", "This is the first achievement", "Assets/Resources/Sprites/Achievements/..."),
            new Achievement
            ("Island cleaned", "This is the second achievement", "Assets/Resources/Sprites/Achievements/..."),
            new Achievement
            ("Rampage", "This is the third achievement", "Assets/Resources/Sprites/Achievements/..."),
            new Achievement
            ("Ready for escape", "This is the fourth achievement", "Assets/Resources/Sprites/Achievements/...")
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
        if (_globalObjectRegistry.isPenguinUnlocked)
        {
            UnlockAchievement("A new friend!");
        }

        if (_globalObjectRegistry.collectedTrash >= 100)
        {
            UnlockAchievement("Island cleaned");
        }

        int destroyedObjects = 0;
        foreach (LevelState levelState in _globalObjectRegistry.LevelStates)
        {
            destroyedObjects += levelState.DestroyedObjects.Count;
        }

        if (destroyedObjects >= 100)
        {
            UnlockAchievement("Rampage");
        }
        
        if (_globalObjectRegistry.collectedPieces == 3)
        {
            UnlockAchievement("Ready for escape");
        }
    }
}
