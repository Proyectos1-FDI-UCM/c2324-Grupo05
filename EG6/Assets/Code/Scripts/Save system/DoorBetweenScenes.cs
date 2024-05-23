using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBetweenScenes: MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ChildMovement>() != null)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
