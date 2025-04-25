using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour {
    public float coolDown;
    public float coolDownTimer;
    public float coolDownWeapon;
    public BulletController bullet;
    public Transform firePoint;
    public float bulletSpeed;
    public float bulletDamage;

    // Start is called before the first frame update
    void Update() {
        if (coolDownTimer < coolDown) {
            coolDownTimer += Time.deltaTime;

        }
        if (coolDownTimer > coolDown)
            coolDownTimer = coolDown;

        if (Input.GetMouseButton(1) && coolDownTimer == coolDown) {
            BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
            newBullet.speed = bulletSpeed;
            coolDownTimer = 0;
        }
    }
}