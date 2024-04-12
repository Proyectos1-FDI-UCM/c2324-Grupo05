using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _wrongButtons;
    [SerializeField] private GameObject _correctButtons;

    private void Start()
    {
        _wrongButtons.SetActive(false);
        _correctButtons.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when child enters platforms buttons of each phase appears
        if(collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            _wrongButtons.SetActive(true);
            _correctButtons.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            _wrongButtons.SetActive(false);
            _correctButtons.SetActive(false);
        }
    }

}
