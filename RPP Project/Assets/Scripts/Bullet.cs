using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    void Update()
    {
        Destroy(gameObject, 4f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
