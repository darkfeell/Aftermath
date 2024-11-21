using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            GameManager.instance.playerMove.batteriesCollected++;
            Destroy(gameObject);
        }
    }
}
