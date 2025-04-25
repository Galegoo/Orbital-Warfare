using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarPowerups : MonoBehaviour
{
    public bool isFiring;
    public BulletController powerup;
    public float bulletSpeed;
    public float bulletDamage;
    public float timeBetweenShots;
    public float shotCounter;

    public Transform firePoint;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        BulletController newBullet = Instantiate(powerup, firePoint.position, firePoint.rotation) as BulletController;
        newBullet.speed = bulletSpeed;
    }
    
}
