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
        
    }
    

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


    protected virtual void ShowRetryMenu()
    {
        _retryPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}

