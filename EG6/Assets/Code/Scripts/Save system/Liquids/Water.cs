using UnityEngine;


/// <summary>
/// This class is used to reset the level when child falls into the water
/// For pengiun it changes the movement mode to swimming
/// </summary>
public class Water : LevelResetter
{
    AudioManager _audioManager;
    
    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            collision.GetComponent<ChildMovement>().enabled = false;
        }

        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            _anim.SetTrigger("Die2"); //Iniciates the animation
            _audioManager.PlaySFX(_audioManager._death);
            /*
            AudioClip onPressedSound = Resources.Load<AudioClip>("Audio/death/DeathSound");
            AudioSource.PlayClipAtPoint(onPressedSound, transform.position);
            */
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
