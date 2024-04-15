using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBedroom : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ChildMovement>() != null)
        {
            Debug.Log("Entra para select level");
            SceneManager.LoadScene(_sceneName);
        }
    }
    
}
