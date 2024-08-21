using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public bool allowButtonHold;
    int maxAmmo, currentAmmo, bulletsPerTap, bulletsShot;

    public bool isShooting, readyToShoot, isReloading;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void MyInput(){
        if(allowButtonHold) isShooting = Input.GetKey("Fire1");
        else isShooting = Input.GetKeyDown("Fire1");

        if(currentAmmo <= 0 && !isReloading) StartCoroutine(Reload());

        if(readyToShoot && isShooting && !isReloading && currentAmmo > 0) Shoot();
    }
    void Shoot(){
        float x = Random.Range(-spread, spread);
        float y = Random.Range(spread, -spread);

        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);


        readyToShoot = false;
        currentAmmo--;
        Invoke("ResetShot", timeBetweenShooting);
    }
    void ResetShot(){
        readyToShoot = true;
    }
    IEnumerator Reload(){
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
