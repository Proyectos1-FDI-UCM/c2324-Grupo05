using UnityEngine;


/// <summary>
/// This class is used to reset the level when child falls into the water
/// For pengiun it changes the movement mode to swimming
/// </summary>
public class Water : LevelResetter
{
    [SerializeField]private Animator anim;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            collision.GetComponent<ChildMovement>().enabled = false;
        }

        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            anim.SetTrigger("Die2"); //Iniciates the animation
        }
        else if (collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            PenguinMovement penguinMovement = collision.gameObject.GetComponent<PenguinMovement>();
            penguinMovement.MovementMode = MovementMode.Swimming;
            penguinMovement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            ShowRetryMenu();
        }
    }


    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            PenguinMovement penguinMovement = collision.gameObject.GetComponent<PenguinMovement>();
            penguinMovement.MovementMode = MovementMode.Walking;
            penguinMovement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
