using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2NavePrincipal : MonoBehaviour
{
    public float coolDown;
    public float coolDownTimer;
    public float coolDownTimerWeapon;
    private float coolDownTimerWeaponAux;
    public float coolDownWeapon;
    public MissilNavePrincipal bullet;
    public Transform firePoint;
    public float bulletSpeed;
    public float bulletDamage;
    public int MaxMisseis;
    public int misseisDisponiveis;

    public GameObject[] navesInimigas;
    public bool desativaBotaoDireito = false;
    // Start is called before the first frame update
    void Start()
    {
        misseisDisponiveis = MaxMisseis;
        coolDownTimerWeaponAux = coolDownWeapon;
    }

    // Update is called once per frame
    void Update() {
        navesInimigas = GameObject.FindGameObjectsWithTag("naveInimiga");

        if (navesInimigas.Length <= 0)//verifica se existem naves inimigas no ecrã
            desativaBotaoDireito = true;
        else
            desativaBotaoDireito = false;

        if (coolDownTimer > 0) {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer < 0)
            coolDownTimer = 0;

        if (coolDownTimerWeapon > 0)
            coolDownTimerWeapon -= Time.deltaTime;


        if (coolDownTimerWeapon < 0) {//carrega um ou mais misseis
            if (misseisDisponiveis < MaxMisseis - 1) {
                misseisDisponiveis++;
                coolDownTimerWeapon = coolDownWeapon;
            }else if(misseisDisponiveis < MaxMisseis) {
                misseisDisponiveis++;
                coolDownTimerWeapon = 0;
            }
        }

        if (desativaBotaoDireito == false)
            if(misseisDisponiveis > 0)
                if (Input.GetMouseButton(1) && coolDownTimer == 0) {
                    MissilNavePrincipal newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as MissilNavePrincipal;
                    newBullet.speed = bulletSpeed;
                    coolDownTimer = coolDown;
                    coolDownTimerWeapon = coolDownWeapon;
                    misseisDisponiveis--;
                    Debug.Log(misseisDisponiveis);
                }
    }
}
