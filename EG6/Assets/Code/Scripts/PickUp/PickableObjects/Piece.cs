using UnityEngine;
using LevelState = GlobalObjectRegistry.LevelState;

/// <summary>
/// Class for the piece pickable object
/// Teleports the player to the Bedroom scene
/// Overwrites the last unlocked checkpoint
/// </summary>
public class Piece : PickableObject
{
    [SerializeField] private Checkpoint _nextCheckpoint;
    [SerializeField] private SceneTransition _transitionScene;
    [SerializeField] private bool _isUnlockLastLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null || collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            
            _localObjectHandler.SaveLocalState();
            PickUp();
            _transitionScene.ChangeScene(true);
        }
    }


    public override void PickUp()
    {
        _localObjectHandler.SetLastCheckpoint(_nextCheckpoint);
        GlobalObjectRegistry.instance.collectedPieces++;
        GlobalObjectRegistry.instance.isPenguinUnlocked = true;
        if (_isUnlockLastLevel)
        {
            LevelState lastLevelState = GlobalObjectRegistry.instance.GetLevelState("Level3");
            lastLevelState.LastCheckpointID = 2;
            GlobalObjectRegistry.instance.SaveLevelState(lastLevelState.PickedObjects, lastLevelState.OpenedDoors, lastLevelState.DestroyedObjects, lastLevelState.PressedButtons, lastLevelState.LastCheckpointID, "Level3");

            FindAnyObjectByType<AchievementNotifier>().ShowNotify();
        }

        if (GlobalObjectRegistry.instance.collectedPieces == 3)
        {
            FindAnyObjectByType<AchievementNotifier>().ShowNotify();
        }

        AudioManager audioManager = FindAnyObjectByType<AudioManager>();
        audioManager.PlaySFX(audioManager._pickUpPiece);

        base.PickUp();
    }

    
}
