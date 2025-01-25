using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source ---------")]

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("------- Audio Clip ---------")]
    public AudioClip background;
    public AudioClip plate;
    public AudioClip correct;
    public AudioClip wrong;
    public AudioClip button;
    public AudioClip pickup;
    public AudioClip delete;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }



}


