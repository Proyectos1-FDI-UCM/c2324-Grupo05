using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickPenguin : MonoBehaviour
{
    [SerializeField] GameObject _egg;
    [SerializeField] GameObject _pannelEgg;
    [SerializeField] GameObject _collider;
    private void Start()
    {
        _egg.SetActive(false);
    }

    public void PutEgg()
    {

        _egg.SetActive(true);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ChildMovement>() != null && GlobalObjectRegistry.instance.isEggPicked && GlobalObjectRegistry.instance.collectedPieces == 1)
        {

            _egg.SetActive(false);
            _pannelEgg.SetActive(false);
            _collider.SetActive(false);
            Destroy(gameObject);
        }
    }
}
