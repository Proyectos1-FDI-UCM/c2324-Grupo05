using UnityEngine;

/// <summary>
/// This class is used to reset the level when the player crosses the reset trigger 
/// In game it is used for water and lava
/// </summary>
public abstract class LevelResetter : MonoBehaviour
{
    protected RetryMenu _retryPanel;
    protected LocalObjectHandler _localObjectHandler;
    protected Animator _anim;

    private void Awake()
    {
        _anim = FindObjectOfType<ChildMovement>().GetComponent<Animator>();
    }

    private void Start()
    {
        _retryPanel = FindAnyObjectByType<RetryMenu>();
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
        KidTestt.OnAnimationFinished += ShowRetryMenu;
    }
    

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            collision.GetComponent<ChildMovement>().enabled = false;
        }
        else if (collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            collision.GetComponent<PenguinMovement>().enabled = false;
        }
    }

    private void OnDestroy()
    {
        KidTestt.OnAnimationFinished -= ShowRetryMenu; //Desuscribe method
    }
    protected virtual void ShowRetryMenu()
    {
        _retryPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}

