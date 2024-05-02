using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _audioSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
        
    }

    public void SetMusicVolume()
    {
        float volume = _audioSlider.value;
        _audioMixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }

    private void LoadVolume()
    {
        _audioSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        SetMusicVolume();
    }
}
