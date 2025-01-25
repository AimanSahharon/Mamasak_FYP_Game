using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettingsCookingLevel : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    //[SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("music2Volume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            //SetSFXVolume();
        }
        
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("music2", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("music2Volume", volume);
    }
     /*public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    } */

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music2Volume");
       // SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetMusicVolume();
        //SetSFXVolume();
    
    }
}
