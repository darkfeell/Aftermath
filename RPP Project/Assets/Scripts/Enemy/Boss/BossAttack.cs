using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public BossStates stateBoss;
    public Transform playerTransform;
    public Transform aim;
    private BossHealth health;
    public GameObject bullet;
    public Animator anim;
    private Transform firePoint;
    //private AudioSource audio;


    [Header("Configs State 1")]
    public float timeForFirstAttack;
    public int shots;
    public float angleShotBreak;
    public float attackCooldown;
    public float waveAttackCooldown;
    private float waveCooldownTimer;
    public int waveCounter;
    private bool attacking;
    [Header("Configs State 2")]
    public float timerToAttack2State;
    private float currentTimerToAttack;


    void Start()
    {
        health = GetComponent<BossHealth>();
        // playerTransform = PlayerManager.Instance.transform;
        waveCooldownTimer = waveAttackCooldown;
        currentTimerToAttack = timerToAttack2State;
        health.canTakeDamage = true;
        anim = GetComponent<Animator>();
        firePoint = aim.GetChild(0);
        // audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        //anim.SetFloat("Horizontal", firePoint.position.x);
        //anim.SetFloat("Vertical", firePoint.position.y);
        switch (stateBoss)
        {
            case BossStates.State1:
                UpdateStateOne();
                break;
            case BossStates.State2:
                UpdateStateTwo();
                break;
        }
    }

    void UpdateStateOne()
    {
        if (WaveCooldownTimer())
        {
            StartCoroutine(FirstStateAttack());
            waveCooldownTimer = waveAttackCooldown;
        }
        bool WaveCooldownTimer()
        {
            if (attacking == true)
            {
                return false;
            }
            waveCooldownTimer -= Time.deltaTime;
            return waveCooldownTimer <= 0;
        }
    }
    void UpdateStateTwo()
    {
        health.canTakeDamage = true;
        LookToPlayer();
        if (TimerToShoot())
        {
            Shoot();
            anim.SetBool("bossAtk", true);
            currentTimerToAttack = timerToAttack2State;
        }

        bool TimerToShoot()
        {
            currentTimerToAttack -= Time.deltaTime;
            return currentTimerToAttack <= 0;
        }
    }

    void LookToPlayer()
    {
        Vector3 aimDirection = playerTransform.position - transform.position;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        aim.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, aim.rotation);
        AudioObserver.OnPlaySfxEvent("bossAtk");

    }



    IEnumerator FirstStateAttack()
    {
        attacking = true;
        anim.SetBool("bossAtk", true);
        float startAngle = Random.Range(0, 360);
        health.canTakeDamage = false;
        for (int i = 0; i < waveCounter; i++)
        {
            int direction = 1;

            if (Random.value <= 0.5f)
            {
                direction = -1;
            }

            for (int j = 0; j < shots; j++)
            {
                aim.rotation = Quaternion.Euler(0f, 0f, angleShotBreak * j * direction + startAngle);
                Shoot();
                yield return new WaitForSeconds(timeForFirstAttack);
            }


            yield return new WaitForSeconds(attackCooldown);
        }
        health.canTakeDamage = true;
        attacking = false;
        anim.SetBool("bossAtk", false);
    }
}
public enum BossStates
{
    State1, State2
} 


