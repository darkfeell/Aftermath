using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
   

{
    public float timeDestroy;
    void Update()
    {
        Destroy(gameObject, timeDestroy);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        
    }
}
