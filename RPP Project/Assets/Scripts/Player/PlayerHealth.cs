using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
    //public int healAmount;
    public HealthBar bar;
    public GameObject player;
    public SpriteRenderer sprite;
    public PlayerMovement mov;
    public PlayerShooting shoot;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        bar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        bar.SetHealth(currentHealth);
        sprite.color = Color.blue;
        if(currentHealth <= 0) StartCoroutine("PlayerDeath");
       
                 
                 
                 
        
    }
    

    public IEnumerator PlayerDeath()
    {
        currentHealth = 0;
        bar.SetHealth(currentHealth);
        sprite.color = Color.red;
        shoot.enabled = false;
        mov.enabled = false;
        mov.rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
    }

    public void PlayerHeal(int healAmount)
    {
        currentHealth += healAmount;
        bar.SetHealth(currentHealth);
    }

    void OnEnable()
    {
        HealthObserver.healthGainedEvent += PlayerHeal;
    }
    void OnDisable()
    {
        HealthObserver.healthGainedEvent += PlayerHeal;
    }
}
