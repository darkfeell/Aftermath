using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    
    public PlayerHealth health;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("colidiu");
            health.PlayerHeal(10);
            Destroy(gameObject);
        }
        
    }
}
