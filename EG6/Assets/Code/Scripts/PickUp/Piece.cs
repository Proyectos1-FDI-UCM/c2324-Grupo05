using UnityEngine;
using UnityEngine.SceneManagement;

public class Piece : PickableObject
{
    [SerializeField] private PieceCounter _counter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            PickUp();
            _localObjectHandler.SaveLocalState();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public override void PickUp()
    {
        _counter.IncrementCount();
        base.PickUp();
        
    }
}
