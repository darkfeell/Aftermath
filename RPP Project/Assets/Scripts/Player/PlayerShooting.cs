using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private bool isReloading = false;
    public bool canFire;

    public float bulletForce;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;
    public float fireTimer;
    public float reloadTimer;
    public float timeBetweenFiring;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.SetAmmoText();
        if (isReloading)
        {
            reloadTimer += Time.deltaTime;
            GameManager.instance.ShowReloadTimer(reloadTimer);
            if (reloadTimer > reloadTime)
            {
                GameManager.instance.DisableReloadTimer();
                reloadTimer = 0;
            }
            return;

        }
        
        if(currentAmmo <= 0){
            StartCoroutine(Reload());
            return;
        }
        if (!canFire)
        {
            fireTimer += Time.deltaTime;
            if(fireTimer > timeBetweenFiring)
            {
                canFire = true;
                fireTimer = 0;
            }
        }
        if (Input.GetButton("Fire1") && canFire && PauseMenu.isGamePaused == false)
        {
            StartCoroutine("Shoot");
        }
    }

    IEnumerator Shoot()
    {
        canFire = false;
        currentAmmo--;
        GameManager.instance.playerMove.anim.SetBool("isShooting", true);
        AudioObserver.OnPlaySfxEvent("shot");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        GameManager.instance.playerMove.anim.SetBool("isShooting", false);
    }

    IEnumerator Reload(){
        isReloading = true;
        AudioObserver.OnPlaySfxEvent("reload");
        yield return new WaitForSeconds(reloadTime);
        
        currentAmmo = maxAmmo;
        isReloading = false;
        
    }
    void OnEnable()
    {
        GameManager.instance.SetShootScript(this);
    }
}
