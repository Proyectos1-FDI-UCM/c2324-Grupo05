using UnityEngine;

public class FloatingSelectArrow : MonoBehaviour
{
    public float floatingHeight = 0.2f; 
    public float floatingSpeed = 0.5f; 

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatingSpeed) * floatingHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
