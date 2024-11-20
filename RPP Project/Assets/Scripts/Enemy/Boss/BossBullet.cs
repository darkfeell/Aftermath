using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    //public CircleCollider2D CircleCol;
    public float speed;
    public int damageValue;

    private void Start()
    {
        Invoke("Death", 5f);
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameManager.instance.hp.SetUpDamage(damageValue);
            GameManager.instance.hp.TakeDamage();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
    
}
