using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicSource, sfxSource;

    public AudioClip dashClip, colectableClip;
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
        }
    }
}
