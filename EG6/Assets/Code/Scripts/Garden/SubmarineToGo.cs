using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmarineToGo : MonoBehaviour
{
    [SerializeField] GameObject _submarine;
    [SerializeField] GameObject _eggtp;
    [SerializeField] GameObject _egg;
    private void Start()
    {
        _submarine.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null && collision.gameObject.GetComponent<PenguinMovement>() != null)
        {

            _egg.transform.position = _eggtp.transform.position;
            _submarine.SetActive(true);

        }
    }
}
