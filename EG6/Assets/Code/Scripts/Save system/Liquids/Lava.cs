using UnityEngine;


/// <summary>
/// This class is used to reset the level when 
/// the player or piece falls into the lava
/// </summary>
public class Lava : LevelResetter
{
    AudioManager _audioManager;

    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.gameObject.GetComponent<ChildMovement>() != null || collision.gameObject.GetComponent<PenguinMovement>() != null || collision.gameObject.GetComponent<Piece>() != null)
        {
            if (collision.gameObject.GetComponent<ChildMovement>() != null)
            {
                _anim.SetTrigger("Die"); //Iniciates the animation

                _audioManager.PlaySFX(_audioManager._death);
                /*
                AudioClip onPressedSound = Resources.Load<AudioClip>("Audio/death/DeathSound");
                AudioSource.PlayClipAtPoint(onPressedSound, transform.position);
                */
                
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
