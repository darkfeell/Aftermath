using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeBar : MonoBehaviour
{
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    void OnVolumeSliderChanged(float volume)
    {
        AudioObserver.OnVolumeChangedEvent(volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
