using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ParticleObserver 
{
    public static event Action<Vector3> particleSpawnEvent;

    public static void OnParticleSpawnEvent(Vector3 obj){
        particleSpawnEvent?.Invoke(obj);
    }
}
