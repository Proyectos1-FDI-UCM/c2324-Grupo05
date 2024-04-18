using UnityEngine;

/// <summary>
/// This class is used to reset the level when the player crosses the reset trigger 
/// In game it is used for water and lava
/// </summary>
public abstract class LevelResetter : MonoBehaviour
{
    [SerializeField] protected RetryMenu _retryPanel;
    protected LocalObjectHandler _localObjectHandler;


    private void Start()
    {
        _localObjectHandler = FindObjectOfType<LocalObjectHandler>();
        KidTestt.OnAnimationFinished += ShowRetryMenu;
    }
    

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<MovableObject>().enabled = false;
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

