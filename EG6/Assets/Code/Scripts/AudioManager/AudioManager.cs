using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("------- AUDIO SOURCES -------")]
    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _SFXSource;

    [Header("------- AUDIO CLIPS -------")]
    [Header("------- Music -------")]
    [SerializeField] AudioClip _initialMenuMusic;
    [SerializeField] AudioClip _bedroomMusic;
    [SerializeField] AudioClip _selectLevelMusic;
    [SerializeField] AudioClip _mapExteriorMusic;
    [SerializeField] AudioClip _level3Music;

    [Header("------- SFX -------")]
    [SerializeField] AudioClip _books;
    [SerializeField] AudioClip _buttonPressed;
    [SerializeField] AudioClip _buttonReleased;
    [SerializeField] AudioClip _doorOpened;
    [SerializeField] AudioClip _death;
    [SerializeField] AudioClip _breakIce;
    [SerializeField] AudioClip _breakWood;
    [SerializeField] AudioClip _hitIce;
    [SerializeField] AudioClip _hitWood;
    [SerializeField] AudioClip _knockIce;
    [SerializeField] AudioClip _knockWood;
    [SerializeField] AudioClip _waterPlatform;



    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //each scene has its own background music
        switch (scene.name)
        {
            case "InitialMenu":
                _musicSource.clip = _initialMenuMusic;
                break;
            case "BedroomTest":
                _musicSource.clip = _bedroomMusic;
                break;
            case "SelectLevel":
                _musicSource.clip = _selectLevelMusic;
                break;
            case "MapExterior":
                _musicSource.clip = _mapExteriorMusic;
                break;
            case "Level3":
                _musicSource.clip = _level3Music;
                break;
          
        }

        
        if (_musicSource.clip != null)
        {
            _musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip) //method to call when sfx has to be played
    {
        _SFXSource.PlayOneShot(clip);
    }

}
