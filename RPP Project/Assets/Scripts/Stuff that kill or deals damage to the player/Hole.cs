using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public PlayerHealth PHealth;

    public float deathTime = 0;

    public float timeToDie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) deathTime = 0;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            deathTime += Time.deltaTime;
            if (deathTime >= timeToDie)
            {
                PHealth.StartCoroutine("PlayerDeath");
                Debug.Log("morreu");
            }
        }
    }
}