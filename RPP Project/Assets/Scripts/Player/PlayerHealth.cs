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
    //public Animator anim;
    public float hitTime;
    
    public int enemyDamage;
    


    public void SetupHealth()
    {
        currentHealth = maxHealth;
        bar.SetMaxHealth(maxHealth);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SetupHealth();
    }

    // Update is called once per frame
    

    public void TakeDamage()
    {
        if (currentHealth <= 0) return;
        
        StartCoroutine("TakingDamage");

        if (currentHealth <= 0) StartCoroutine("PlayerDeath");
    }
    
    public IEnumerator PlayerDeath()
    {
        
        currentHealth = 0;
        enemyDamage = 0;
        bar.SetHealth(currentHealth);
        GameManager.instance.playerMove.anim.SetBool("isDead", true);
        GameManager.instance.playerMove.anim.SetBool("isHit", false);
        GameManager.instance.playerMove.anim.SetBool("isWalking", false);
        GameManager.instance.playerShoot.enabled = false;
        GameManager.instance.playerMove.enabled = false;
        GameManager.instance.playerMove.rb.velocity = Vector2.zero;
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
    public IEnumerator TakingDamage(){
        currentHealth -= enemyDamage;
        bar.SetHealth(currentHealth);
        GameManager.instance.playerMove.anim.SetBool("isHit", true);
        GameManager.instance.playerMove.anim.SetBool("isWalking", false);
        yield return new WaitForSeconds(hitTime);
        GameManager.instance.playerMove.anim.SetBool("isHit", false);
    }
    public void SetUpDamage(int damageTaken){
        enemyDamage = damageTaken;
    }
}
