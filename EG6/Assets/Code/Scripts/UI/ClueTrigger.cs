using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _cluePanel;

    private void Start()
    {
        _cluePanel.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null || collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
                _cluePanel.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null || collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            _cluePanel.SetActive(false);
        }
    }
}
