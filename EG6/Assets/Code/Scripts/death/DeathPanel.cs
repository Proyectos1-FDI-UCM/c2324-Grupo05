using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] GameObject _pannel;
    private void Start()
    {
        _pannel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null || collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            ShowPannel();
         

        }
    }
    private void ShowPannel()
    {
        _pannel.SetActive(true);
        Time.timeScale = 0f;
    }
}
