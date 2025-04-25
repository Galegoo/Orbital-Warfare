using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public SpaceShip naveAtiva;
    
    public Weapon2NavePrincipal gun2;

    public bool podetirarhp = true;
    public bool podetirarhpdenovo = true;
    public float danoDeColisaoComANavePrincipal;
    GameObject gerenciadorDeNaves;
    public SelectedShip referencia;
    private float danoArmaPrincipal;

    private Vector3 posicao;

    public GameObject fractureEnemy;
    public GameObject enemyExplosion;

    /*
    public BulletController powerup; //powerup
    public Transform firePoint; //powerupPosInicial
    public float powerupSpeed;    */

    public float NaveInimigaHP;
    public float maximoz; // ponto de destruição das Naves Inimigas

    // Use this for initialization
    void Awake()
    {
        gerenciadorDeNaves = GameObject.Find("Gerenciador de naves");
        referencia = gerenciadorDeNaves.GetComponent<SelectedShip>();
    }

    // Update is called once per frame
    void Update()
    {
        naveAtiva = gerenciadorDeNaves.GetComponentInChildren<SpaceShip>();
        

        //destroi a nave inimiga depois que ele passa da pozição em z determinada
        if (this.gameObject.transform.position.z < maximoz)
        {
            referencia.PlanetHP -= 2f;
            Destroy(this.gameObject);
        }

        posicao = this.transform.position;
        if(posicao.z < 5) {
            
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (podetirarhp == true)// Infligir dano no jogador quando colidir contra a nave inimiga
        {
            podetirarhp = false;
            if (col.gameObject.tag == "nave" || col.gameObject.tag == "naveCaca" || col.gameObject.tag == "naveTanque")
            {
                if (naveAtiva.escudo <= 0)
                {
                    naveAtiva.healthpoints = naveAtiva.healthpoints - danoDeColisaoComANavePrincipal;
                    StartCoroutine("esperapratirardano");
                }
                else
                {
                    naveAtiva.escudo = naveAtiva.escudo - danoDeColisaoComANavePrincipal;
                    StartCoroutine("esperapratirardano");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (podetirarhpdenovo == true)
        {
            if (other.gameObject.tag == "bala") //inflige dano na nave inimiga quando colide com a bala disparada pelo jogador
            {
                danoArmaPrincipal = naveAtiva.transform.Find("Gun").GetComponent<GunController>().bulletDamage;
                tirarDano();
                
            }
            else if(other.gameObject.tag == "MissilNaveCaca") {
                danoArmaPrincipal = naveAtiva.transform.Find("Gun").GetComponent<Weapon2>().bulletDamage;
                tirarDano();
            }
            Destroy(other.gameObject);
            StartCoroutine("esperapratirardanodenovo");
        }
            /*if (other.gameObject.tag == "missilNavePrincipal") //inflige dano na nave inimiga quando colide com a bala disparada pelo jogador
            {
                podetirarhpdenovo = false;
                NaveInimigaHP -= gun2.bulletDamage;
                Destroy(other.gameObject);
                if (NaveInimigaHP <= 0) {
                    Destroy(this.gameObject);
                    /*float v = Random.Range(1, 3);
                    if (v == 2)
                    {
                        Debug.Log(firePoint.rotation);
                        BulletController newBullet = Instantiate(powerup, firePoint.position, firePoint.rotation) as BulletController;
                        newBullet.speed = powerupSpeed;
                    }
                    
                }
                StartCoroutine("esperapratirardanodenovo");
            }*/
        
    }

    void tirarDano() {
        podetirarhpdenovo = false;
        NaveInimigaHP -= danoArmaPrincipal;
        Debug.Log(NaveInimigaHP);

        if (NaveInimigaHP <= 0) {
            referencia.EnemyDeathSound.Play();
            GameObject novaFracture = Instantiate(fractureEnemy, this.transform.position, this.transform.rotation);
            GameObject novaExplosao = Instantiate(enemyExplosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
    public IEnumerator esperapratirardano() //Função feita para poder chamar o "WaitForSeconds" E demorar um tempo para o jogador não sofrer muito dao de uma colisão só
    {
        yield return new WaitForSeconds(0.5f);
        podetirarhp = true;
    }
    public IEnumerator esperapratirardanodenovo() 
    {
        yield return new WaitForSeconds(0.1f);
        podetirarhpdenovo = true;
    }
}
