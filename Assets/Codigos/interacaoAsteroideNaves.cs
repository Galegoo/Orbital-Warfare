using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interacaoAsteroideNaves : MonoBehaviour {


    public SpaceShip naveAtiva;
    public GunController gun;
    public bool podetirarhp = true;
    public bool criaPowerup = true;
    public float danoDeColisaoComAsteroide;
    GameObject gerenciadorDeNaves;
    
    private float danoArmaPrincipal;
    private float danoArmaSecundaria;


    public GameObject explosionAnimation;
    public Transform firePoint; //powerupPosInicial
    public float powerupSpeed;


    public float asteroideHP;
    public float maximoz; // ponto de destruição dos asteroides
    public float maximotamanho; //tamanho maximo do asteroide
    public float minimotamanho; //tamanho maximo do asteroide


    public GameObject[] powerups;
    public HUDManager hud;


    // Use this for initialization
    void Awake() {
        gerenciadorDeNaves = GameObject.Find("Gerenciador de naves");



        //CAlcular tamanho e volume do asteroide
        float x = Random.Range(maximotamanho, minimotamanho);
        float y = Random.Range(maximotamanho, minimotamanho);
        float z = Random.Range(maximotamanho, minimotamanho);
        asteroideHP = (x * y * z) * 50;
        this.gameObject.transform.localScale = new Vector3(x, y, z);

    }

    // Update is called once per frame
    void Update() {
        naveAtiva = gerenciadorDeNaves.GetComponentInChildren<SpaceShip>();
        hud = GameObject.Find("Canvas").GetComponent<HUDManager>();

        //destroi o asteroide depois que ele passa da pozição em z determinada
        if (this.gameObject.transform.position.z < maximoz) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision col) {

        if (podetirarhp == true)// Infligir dano no jogador quando colidir contra os asteroides
        {
            podetirarhp = false;
            if (col.gameObject.tag == "nave" || col.gameObject.tag == "naveCaca" || col.gameObject.tag == "naveTanque") {
                if (naveAtiva.escudo <= 0) {
                    naveAtiva.healthpoints = naveAtiva.healthpoints - danoDeColisaoComAsteroide;
                    StartCoroutine("esperapratirardano");
                } else {
                    naveAtiva.escudo = naveAtiva.escudo - danoDeColisaoComAsteroide;
                    StartCoroutine("esperapratirardano");
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "bala") {
            danoArmaPrincipal = naveAtiva.transform.Find("Gun").GetComponent<GunController>().bulletDamage;
            if (criaPowerup) {
                asteroideHP -= danoArmaPrincipal;
                if (asteroideHP <= 0) {
                    hud.Score += Random.Range(30, 60);
                    float v = Random.Range(2, 2);
                    if (v == 2) {
                        //Debug.Log(firePoint.rotation);
                        GameObject novaExplosao = Instantiate(explosionAnimation, firePoint.position, firePoint.rotation);
                        GameObject newBullet = Instantiate(powerups[Random.Range(0, powerups.Length)], firePoint.position, firePoint.rotation);
                    }
                    Destroy(this.gameObject);
                }
                criaPowerup = false;
                Destroy(other.gameObject);

            } else
                criaPowerup = true;
        } else if (other.gameObject.tag == "MissilNaveCaca") {
            danoArmaSecundaria = naveAtiva.transform.Find("Gun").GetComponent<Weapon2>().bulletDamage;
            asteroideHP -= danoArmaSecundaria;
            if (asteroideHP <= 0) {
                hud.Score += Random.Range(30, 60);
                float v = Random.Range(2, 2);
                if (v == 2) {
                    Debug.Log(firePoint.rotation);
                    GameObject novaExplosao = Instantiate(explosionAnimation, firePoint.position, firePoint.rotation);
                    GameObject newBullet = Instantiate(powerups[Random.Range(0, powerups.Length)], firePoint.position, firePoint.rotation);

                }
                Destroy(this.gameObject);
            }
            Destroy(other.gameObject);
        }

        /*else if (other.gameObject.tag == "Weapon2Tanque") {

            asteroideHP -= gun2.bulletDamage;
           
            if (asteroideHP <= 0) {
                hud.Score += Random.Range(30, 60);
                Destroy(this.gameObject);

                float v = Random.Range(2, 2);
                if (v == 2) {
                    Debug.Log(firePoint.rotation);

                    GameObject newBullet = Instantiate(powerups[Random.Range(0, powerups.Length)], firePoint.position, firePoint.rotation);

                }
            }
            Destroy(other.gameObject);
        }*/
    }


    public IEnumerator esperapratirardano() //Função feita para poder chamar o "WaitForSeconds" E demorar um tempo para o jogador não sofrer muito dao de uma colisão só
    {
        yield return new WaitForSeconds(0.5f);
        podetirarhp = true;
    }
}