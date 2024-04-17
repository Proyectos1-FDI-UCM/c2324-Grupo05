using UnityEngine;


/// <summary>
/// This class is used to reset the level when 
/// the player or piece falls into the lava
/// </summary>
public class Lava : LevelResetter
{

    [SerializeField] private Animator anim;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null || collision.gameObject.GetComponent<PenguinMovement>() != null || collision.gameObject.GetComponent<Piece>() != null)
        {
            if (collision.gameObject.GetComponent<ChildMovement>() != null)
            {
                anim.SetTrigger("Die");
            }
            else
            {
                ShowRetryMenu();
            }

        }
        //if (collision.gameObject.GetComponent<Ice>() != null)
        //{
        //    Destroy(collision.gameObject);
        //}
    }
}
