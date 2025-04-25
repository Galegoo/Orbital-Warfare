using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunController : MonoBehaviour
{

    public bool isFiring;
    public EnemyBullet bulletNormal;
    public EnemyBulletCaca1 bulletCaca;
    public float bulletSpeed;
    public float bulletDamage;
    public float timeBetweenShotsMIN;
    public float timeBetweenShotsMAX;
    public float shotCounter;


    public Transform firePoint;

    GameObject gerenciadorDeNaves;
    public SpaceShip naveAtiva;
    private Vector3 posNaveActiva;

    private GameObject nave;
    private Vector3 posNave;
    public float ZMinParaDisparar;

    // Start is called before the first frame update
    void Start()
    {
        nave = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        posNave = nave.transform.position;


        if (isFiring)
        {
            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                if (posNave.z > ZMinParaDisparar)
                {
                    shotCounter = UnityEngine.Random.RandomRange(timeBetweenShotsMIN, timeBetweenShotsMAX);
                    if (this.gameObject.transform.parent.tag == "naveInimiga")
                    {
                        EnemyBullet newBullet = Instantiate(bulletNormal, firePoint.position, firePoint.rotation) as EnemyBullet;
                        newBullet.speed = bulletSpeed;
                    }
                    else if (this.gameObject.transform.parent.tag == "naveInimigaCaca")
                    {
                        EnemyBulletCaca1 newBullet = Instantiate(bulletCaca, firePoint.position, firePoint.rotation) as EnemyBulletCaca1;
                        newBullet.speed = bulletSpeed;
                    }
                    else if (this.gameObject.transform.parent.tag == "naveInimigaCacaSpawnNormal")
                    {
                        EnemyBullet newBullet = Instantiate(bulletNormal, firePoint.position, firePoint.rotation) as EnemyBullet;
                        newBullet.speed = bulletSpeed;
                    }
                    else if (this.gameObject.transform.parent.tag == "Boss")
                    {
                        EnemyBullet newBullet = Instantiate(bulletNormal, firePoint.position, firePoint.rotation) as EnemyBullet;
                        newBullet.speed = bulletSpeed;
                    }
                }
            }
        }
    }
}
