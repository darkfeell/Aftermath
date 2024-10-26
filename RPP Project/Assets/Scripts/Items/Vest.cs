using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vest : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.instance.hp.maxHealth = 150;
            Destroy(gameObject);
        }
    }
}
