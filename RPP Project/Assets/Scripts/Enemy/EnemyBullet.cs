using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
   

{
    public GameManager instance;
    public int damageCaused;
    public float timeDestroy;
    void Update()
    {
        Destroy(gameObject, timeDestroy);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            GameManager.instance.hp.SetUpDamage(damageCaused);
            GameManager.instance.hp.TakeDamage();
        }
        
        Debug.Log("collidiu");
        Destroy(gameObject);
        
    }
}
