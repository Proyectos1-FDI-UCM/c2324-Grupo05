using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for the piece pickable object
/// Teleports the player to the BedroomTest scene
/// </summary>
public class Piece : PickableObject
{
    [SerializeField] private PieceCounter _counter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            PickUp();
            _localObjectHandler.SaveLocalState();
            SceneManager.LoadScene("BedroomTest");
        }
    }

    public override void PickUp()
    {
        _counter.IncrementCount();
        base.PickUp();
        
    }
}
