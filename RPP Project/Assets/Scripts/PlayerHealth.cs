using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damageTaken;
    public int healAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= maxHealth)
        {
            TakeDamage();
            if (currentHealth < maxHealth)
            {
                PlayerHeal();
            }
        }
    }

    void TakeDamage()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            currentHealth -= damageTaken;
            PlayerDeath();
        }
        
    }

    void PlayerDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayerHeal()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentHealth += healAmount;
        }
    }
}
