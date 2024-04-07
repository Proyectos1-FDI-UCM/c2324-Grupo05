using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for the piece pickable object
/// Teleports the player to the BedroomTest scene
/// </summary>
public class Piece : PickableObject
{
    [SerializeField] private PieceCounter _counter;
    [SerializeField] private Checkpoint _nextCheckpoint;
    [SerializeField] private SceneTransition _transitionScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null || collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            PickUp();
            _localObjectHandler.SaveLocalState();

            _transitionScene.ChangeScene(true);
            //SceneManager.LoadScene("Cinematica");

        }
    }

    public override void PickUp()
    {
        _counter.IncrementCount();
        _localObjectHandler.SetLastCheckpoint(_nextCheckpoint);
        GlobalObjectRegistry.instance.collectedPieces++;
        base.PickUp();
        
    }

    
}
