using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2Tanque : MonoBehaviour {
    public float coolDownArma = 3;
    public float coolDownArmaMax;
    public float coolDownProximaBala;
    private float proximaBala;
    public BulletController bullet;
    public Transform firePoint;
    public float bulletSpeed;
    public float bulletDamage;

    public bool naoPodeDisparar;
    public bool controle;

    // Start is called before the first frame update
    void Start() {
        coolDownArmaMax = coolDownArma;
    }

    // Update is called once per frame


    void Update() {

        if (naoPodeDisparar == false) {
            coolDownArma -= Time.deltaTime;
        } else if (naoPodeDisparar == true) {
            coolDownArma += Time.deltaTime;
        }
        if (coolDownArma <= 0) {
            naoPodeDisparar = true;
            coolDownArma = 0;
        }
        if (coolDownArma >= coolDownArmaMax) {
            if (Input.GetMouseButton(1)) {
                naoPodeDisparar = false;
            }
            coolDownArma = coolDownArmaMax;
        }

        if (naoPodeDisparar == false) {
            if (proximaBala > 0) {
                proximaBala -= Time.deltaTime;

            }
            if (proximaBala < 0)
                proximaBala = 0;

            if (Input.GetMouseButton(1) && proximaBala == 0) {
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
                newBullet.speed = bulletSpeed;
                proximaBala = coolDownProximaBala;
            }
        }

    }
}