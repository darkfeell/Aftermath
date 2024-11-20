using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float volume;
    public static AudioManager instance;

    public AudioSource musicSource, sfxSource;

    public AudioClip dashClip, medkitClip, buttonUIClip, shotClip, reloadClip, damageClip, walkClip;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaySfx(string clipName)
    {
        switch (clipName)
        {
            case "dash":
                sfxSource.PlayOneShot(dashClip);
                break;
            case "medkit":
                sfxSource.PlayOneShot(medkitClip);
                break;
            case "button":
                sfxSource.PlayOneShot(buttonUIClip);
                break;
            case "shot":
                sfxSource.PlayOneShot(shotClip);
                break;
            case "reload":
                sfxSource.PlayOneShot(reloadClip);
                break;
            case "damage":
                sfxSource.PlayOneShot(damageClip);
                break;
            case "walk":
                sfxSource.PlayOneShot(walkClip);
                break;
            default:
                Debug.LogError($"SOUND EFFECT {clipName} NOT FOUND");
                break;
        }
    }

    void PlayMusic()
    {
        musicSource.Play();
    }

    void StopMusic()
    {
        musicSource.Stop();
    }

    private void OnEnable()
    {
        AudioObserver.PlayMusicEvent += PlayMusic;
        AudioObserver.StopMusicEvent += StopMusic;
        AudioObserver.PlaySfxEvent += PlaySfx;
        AudioObserver.volumeChangedEvent += ProcessVolumeChanged;
    }

    private void OnDisable()
    {
        AudioObserver.PlayMusicEvent -= PlayMusic;
        AudioObserver.StopMusicEvent -= StopMusic;
        AudioObserver.PlaySfxEvent -= PlaySfx;
        AudioObserver.volumeChangedEvent -= ProcessVolumeChanged;
    }

    void ProcessVolumeChanged(float value)
    {
        volume = value;
    }
}
