using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class AudioObserver 
{
    public static event Action<string> PlaySFXEvent;

    public static event Action PlayMusicEvent;
    public static event Action StopMusicEvent;

    public static void OnPlaySFXEvent(string obj)
    {
        PlaySFXEvent?.Invoke(obj);
    }
    public static void OnPlayMusicEvent()
    {
        PlayMusicEvent?.Invoke();
    }
    public static void OnStopMusicEvent()
    {
        StopMusicEvent?.Invoke();
    }

}
