using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongButton : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _playerNewPosition;
    [SerializeField] GameObject _platform;
    [SerializeField] GameObject _pannelWaterDeath;
    [SerializeField] float _time=5.0f;

    private void Start()
    { 
    
        _pannelWaterDeath.SetActive(false);
    
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PenguinMovement>() != null)
        {
            _platform.SetActive(false);
            
            _pannelWaterDeath.SetActive(true); 
            StartCoroutine(Wait());
            _pannelWaterDeath.SetActive(false);
            _platform.SetActive(true);
            _player.transform.position = _playerNewPosition.transform.position;


        }


    }

    private IEnumerator Wait()
    {
       
        yield return new WaitForSeconds(_time);
  


    }


}
