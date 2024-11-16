using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeChip : MonoBehaviour
{
    public int newMaxAmmo;
    public float newReloadTime;
    public float newTimeBetweenFiring;
    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            GameManager.instance.playerShoot.maxAmmo = newMaxAmmo;
            GameManager.instance.playerShoot.reloadTime = newReloadTime;
            GameManager.instance.playerShoot.timeBetweenFiring = newTimeBetweenFiring;
            Destroy(gameObject);
        }
    }
}
