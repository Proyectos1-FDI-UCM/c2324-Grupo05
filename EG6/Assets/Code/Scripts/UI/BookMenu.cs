using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    //public AudioSource Sonido;
    AudioManager _audioManager;
   

    private void Start()
    {
        _menu.SetActive(false);
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<ChildMovement>() != null)
        {
            _audioManager.PlaySFX(_audioManager._books);


            _menu.SetActive(true);
            Time.timeScale = 0f;

        }


    }

   
}
