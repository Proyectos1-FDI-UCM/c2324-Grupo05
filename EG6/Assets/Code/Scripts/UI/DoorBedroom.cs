using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBedroom : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<ChildMovement>() != null)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}
