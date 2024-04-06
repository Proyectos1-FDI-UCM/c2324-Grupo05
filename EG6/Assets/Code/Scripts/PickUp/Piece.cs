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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null || collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            PickUp();
            _localObjectHandler.SaveLocalState();

            SceneManager.LoadScene("Cinematica");

            //SceneManager.LoadScene("BedroomTest");
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
