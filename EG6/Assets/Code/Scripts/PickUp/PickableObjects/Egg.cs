using UnityEngine;

/// <summary>
/// This class is used to pick up the egg, which is unique pickable object in the game.
/// </summary>
public class Egg : PickableObject
{
    [SerializeField] private Checkpoint _nextCheckpoint;
    [SerializeField] private SceneTransition _transitionScene;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            PickUp();
            
            FindAnyObjectByType<AchievementNotifier>().ShowNotify();
            
            _transitionScene.ChangeScene(true);
        }
    }

    public override void PickUp()
    {
        base.PickUp();
        GlobalObjectRegistry.instance.isEggPicked = true;
    }
}
