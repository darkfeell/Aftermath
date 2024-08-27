using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : MonoBehaviour
{
    public PlayerHealth PHealth;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("colidiu");
        if (other.CompareTag("Player")) PHealth.StartCoroutine("PlayerDeath");

    }
}
