using UnityEngine;

public class IceDespawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MovableObject>()!= null)
        {
            Destroy(collision.gameObject);
        }
    }
}
