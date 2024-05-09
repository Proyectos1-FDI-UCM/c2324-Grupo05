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
    public Animator anim;
    public GameObject Question;
    private void Start()
    {

         anim = anim.GetComponent<Animator>();
        _globalObjectRegistry = GlobalObjectRegistry.instance;

        _achievements = new List<Achievement>
        {
            new Achievement
            ("Not Alone", "Description: You found yourself a new friend!", "Assets/Resources/Sprites/Achievements/..."),
            new Achievement
            ("Proud Greenpeace", "Description: Greenpeace loves you and admires you", "Assets/Resources/Sprites/Achievements/..."),
            new Achievement
            ("Timbers!", "Description: It's goin' down, I'm yellin' timber", "Assets/Resources/Sprites/Achievements/..."),
            new Achievement
            ("What about light?", "Description: All is darkness and I am darkness", "Assets/Resources/Sprites/Achievements/..."),
            new Achievement
            ("The last of us", "Description: All pieces collected", "Assets/Resources/Sprites/Achievements/..."),
            new Achievement
            ("Safe!", "Description: All trash collected", "Assets/Resources/Sprites/Achievements/..."),
            new Achievement
            ("What about light?", "Unlock level-3", "Assets/Resources/Sprites/Achievements/..."),
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
                anim.Play("Logro");
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
