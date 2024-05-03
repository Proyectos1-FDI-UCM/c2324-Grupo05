using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("------- AUDIO SOURCES -------")]
    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioSource _SFXSource;

    [Header("------- SFX -------")]
    [SerializeField] public AudioClip _books;
    [SerializeField] public AudioClip _buttonPressed;
    [SerializeField] public AudioClip _buttonReleased;
    [SerializeField] public AudioClip _doorOpened;
    [SerializeField] public AudioClip _death;
    [SerializeField] public AudioClip _breakIce;
    [SerializeField] public AudioClip _breakWood;
    [SerializeField] public AudioClip _hitIce;
    [SerializeField] public AudioClip _hitWood;
    [SerializeField] public AudioClip _knockIce;
    [SerializeField] public AudioClip _knockWood;
    [SerializeField] public AudioClip _waterPlatform;
    [SerializeField] public AudioClip _lockedDoor;



    public void PlaySFX(AudioClip clip) //method to call when sfx has to be played
    {
        _SFXSource.PlayOneShot(clip);
    }

}
