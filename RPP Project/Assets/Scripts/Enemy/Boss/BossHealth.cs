using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health;
    public bool canTakeDamage;
    public BossAttack attackBoss;
    private int maxHealth;
    public Bullet playerBullet;
    //public LevelManager levelManager;

    public HealthBar bossHealthBar;

   // public void Damage(float damage)
   // {

        //if (canTakeDamage)
        //{
         //   health -= damage;
            

       // }
        //bossHealthBar.fillAmount = health / maxHealth;
 //   }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "pbullet" && canTakeDamage)
        {
            health -= playerBullet.damage;
            bossHealthBar.SetHealth(health);
        }
    }

    public void Death()
    {
        health = 0;
        bossHealthBar.SetHealth(health);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        bossHealthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= maxHealth * 0.5f)
        {
            attackBoss.stateBoss = BossStates.State2;
        }
        if (health <= 0)
        {
            Death();
        }
    }
}
