using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageTaken;
    //public int healAmount;
    public HealthBar bar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        bar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    

    public void TakeDamage()
    {
        currentHealth -= damageTaken;
        bar.SetHealth(currentHealth);
        PlayerDeath();
       
                 
                 
                 
        
    }

    void PlayerDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void PlayerHeal(int healAmount)
    {
        currentHealth += healAmount;
        bar.SetHealth(currentHealth);
    }
}
