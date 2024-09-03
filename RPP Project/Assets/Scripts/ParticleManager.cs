using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject particle;
    

    private void OnEnable(){
        ParticleObserver.particleSpawnEvent += SpawnParticles;
    }
    private void OnDisable(){
        ParticleObserver.particleSpawnEvent -= SpawnParticles;
    }

    public void SpawnParticles(Vector3 position){
        Instantiate(particle, position, Quaternion.identity);
    }
}
