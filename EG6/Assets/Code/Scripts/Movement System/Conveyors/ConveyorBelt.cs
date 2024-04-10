using UnityEngine;


/// <summary>
/// This class is used to move objects that are inside the trigger area of the conveyor belt.
/// It can move objects only if they have the MovableObject component.
/// </summary>
public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private Vector2 _pushDirection;
    [SerializeField] private float _pushSpeed = 2f;

    public Vector2 PushDirection { get => _pushDirection; set => _pushDirection = value; }


    private void Start() 
    {
        _pushDirection = _pushDirection.normalized;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<MovableObject>() != null)
        {
            MovableObject movableObject = collision.GetComponent<MovableObject>();
            movableObject.AdditionalVector = _pushDirection * _pushSpeed;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MovableObject>() != null)
        {
            MovableObject movableObject = collision.GetComponent<MovableObject>();
            movableObject.AdditionalVector = Vector2.zero;
        }
    }
}
