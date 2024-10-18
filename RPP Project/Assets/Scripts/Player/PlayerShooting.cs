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
    public float timer;
    public float timeBetweenFiring;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(isReloading) return;
        if(currentAmmo <= 0){
            StartCoroutine(Reload());
            return;
        }
        if (!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetButton("Fire1") && canFire && PauseMenu.isGamePaused == false)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        canFire = false;
        currentAmmo--;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    IEnumerator Reload(){
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
