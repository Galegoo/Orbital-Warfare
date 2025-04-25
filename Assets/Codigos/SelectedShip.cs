using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectedShip : MonoBehaviour
{
    public SpaceShip naveAtivada;
    GameObject gerenciadorDeNaves;
    public GameObject popUpGameOver;
    public int selectedspaceship = 0;
    public int guardador = 0;

    public bool nave0morreu = false;
    public bool nave1morreu = false;
    public bool nave2morreu = false;
    GameObject[] AsteroidesNaCena;

    public GameObject NaveCaça;
    public GameObject NaveMedia;
    public GameObject NaveTanque;

    public SpaceShip NaveCaçaScript;
    public SpaceShip NaveMediaScript;
    public SpaceShip NaveTanqueScript;

    public GunController armanave1;
    public GunController armanavecaca;
    public GunController armanavetanque;
    public GunController armaAtiva;

    public float PlanetHP;
    public float maxPlanetHP;

    public float ArmazenadorDeVelocidade;
    public float ArmazenadorDeVelocidadeCaca;
    public float ArmazenadorDeVelocidadeTanque;

    public bool fixpowerup = false;
    public bool fixpowerupCaca = false;
    public bool fixpowerupTanque = false;

    public bool fixpoweupFireRate = false;
    public bool fixpoweupFireRateCaca = false;
    public bool fixpoweupFireRateTanque = false;

    public float ArmazenadorDeFireRate;
    public float ArmazenadorDeFireRateCaca;
    public float ArmazenadorDeFireRateTanque;
    public float FireRate;

    public AudioSource PlayerDeathSound;
    public AudioSource EnemyDeathSound;
    public AudioSource lasershotSound;
    public AudioSource specialShotSound;
    public AudioSource PowerUpPickUpSound;

    public Image crossHair;
    public GameObject objetoAlvoo;

    public GameObject explosaoNave;
    public GameObject fractureEnemy;
    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        NaveMediaScript = NaveMedia.GetComponent<SpaceShip>();
        NaveCaçaScript = NaveCaça.GetComponent<SpaceShip>();
        NaveTanqueScript = NaveTanque.GetComponent<SpaceShip>();
        gerenciadorDeNaves = GameObject.Find("Gerenciador de naves");
        naveAtivada = gerenciadorDeNaves.GetComponentInChildren<SpaceShip>();
        FireRate = armanave1.timeBetweenShots;
        ArmazenadorDeFireRate = armanave1.timeBetweenShots;
        ArmazenadorDeFireRateCaca = armanavecaca.timeBetweenShots;
        ArmazenadorDeFireRateTanque = armanavetanque.timeBetweenShots;
        ArmazenadorDeVelocidade = NaveMediaScript.speed;
        ArmazenadorDeVelocidadeCaca = NaveCaçaScript.speed;
        ArmazenadorDeVelocidadeTanque = NaveTanqueScript.speed;
        SelectShip();
    }

    // Update is called once per frame
    void Update()
    {
        //naveAtivada = gerenciadorDeNaves.GetComponentInChildren<SpaceShip>();
        crossHair.transform.position = Input.mousePosition;
        //crossHair.transform.position = transform.TransformDirection(crossHair.transform.position);

        int previousSelectedShip = selectedspaceship;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedspaceship >= transform.childCount - 1)
            {

                selectedspaceship = 0;
            }
            else
            {
                selectedspaceship++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedspaceship <= 0)
            {
                selectedspaceship = transform.childCount - 1;
            }
            else
            {
                selectedspaceship--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            selectedspaceship = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedspaceship = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedspaceship = 2;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            selectedspaceship = guardador;
        }
        if (previousSelectedShip != selectedspaceship)
        {
            SelectShip();
            guardador = previousSelectedShip;
        }
        SelectShip();
        Morte();
        VerificacaoDaNaveSelecionada();
        RepararEscudo();
        GameOver();
        if (fixpowerup == true)
        {
            StartCoroutine("esperaparaacabarpowerup");
        }
        if (fixpowerupCaca == true)
        {
            StartCoroutine("esperaparaacabarpowerupCaca");
        }
        if (fixpowerupTanque == true)
        {
            StartCoroutine("esperaparaacabarpowerupTanque");
        }
        if (fixpoweupFireRate == true)
        {
            StartCoroutine("esperaparaacabarpowerupFireRate");
        }
        if (fixpoweupFireRateCaca == true)
        {
            StartCoroutine("esperaparaacabarpowerupFireRateCaca");
        }
        if (fixpoweupFireRateTanque == true)
        {
            StartCoroutine("esperaparaacabarpowerupFireRateTanque");
        }
    }
    private void FixedUpdate()
    {
        //troca de cor do cursor quando retorna algum game object
        try
        {
            Debug.Log(naveAtivada.transform.Find("Gun").GetChild(0).GetComponent<RotateToMouse>().hit.collider.gameObject);
            crossHair.color = Color.red;
        }catch(NullReferenceException e)
        {
            crossHair.color = Color.white;
        }
    }
    void SelectShip() //Metodo para definir qual nave está sendo usada
    {
        if (selectedspaceship == 0)
        {
            NaveMedia.gameObject.SetActive(true);
            NaveCaça.gameObject.SetActive(false);
            NaveTanque.gameObject.SetActive(false);
            naveAtivada = NaveMedia.GetComponent<SpaceShip>();
        }
        else if (selectedspaceship == 1)
        {
            NaveMedia.gameObject.SetActive(false);
            NaveCaça.gameObject.SetActive(true);
            NaveTanque.gameObject.SetActive(false);
            naveAtivada = NaveCaça.GetComponent<SpaceShip>();
        }
        else if (selectedspaceship == 2)
        {
            NaveMedia.gameObject.SetActive(false);
            NaveCaça.gameObject.SetActive(false);
            NaveTanque.gameObject.SetActive(true);
            naveAtivada = NaveTanque.GetComponent<SpaceShip>();
        }
    }
    public void Morte()
    {
        try
        {
            if (naveAtivada.healthpoints <= 0)
            {
                if (selectedspaceship == 0)
                {
                    PlayerDeathSound.Play();
                    GameObject novaExplosao = Instantiate(explosaoNave, naveAtivada.transform.position, naveAtivada.transform.rotation);
                    GameObject novaFracture = Instantiate(fractureEnemy, naveAtivada.transform.position, naveAtivada.transform.rotation);
                    nave0morreu = true;
                    if (nave1morreu)
                    {
                        selectedspaceship = 2;
                    }
                    else if (nave2morreu)
                    {
                        selectedspaceship = 1;
                    }
                    else
                    {
                        selectedspaceship = 1;
                    }
                }
                else if (selectedspaceship == 1)
                {
                    PlayerDeathSound.Play();
                    GameObject novaExplosao = Instantiate(explosaoNave, naveAtivada.transform.position, naveAtivada.transform.rotation);
                    GameObject novaFracture = Instantiate(fractureEnemy, naveAtivada.transform.position, naveAtivada.transform.rotation);
                    nave1morreu = true;
                    if (nave0morreu)
                    {
                        selectedspaceship = 2;
                    }
                    else if (nave2morreu)
                    {
                        selectedspaceship = 0;
                    }
                    else
                    {
                        selectedspaceship = 0;
                    }
                }
                else if (selectedspaceship == 2)
                {
                    PlayerDeathSound.Play();
                    GameObject novaExplosao = Instantiate(explosaoNave, naveAtivada.transform.position, naveAtivada.transform.rotation);
                    GameObject novaFracture = Instantiate(fractureEnemy, naveAtivada.transform.position, naveAtivada.transform.rotation);
                    nave2morreu = true;
                    if (nave0morreu)
                    {
                        selectedspaceship = 1;
                    }
                    else if (nave1morreu)
                    {
                        selectedspaceship = 0;
                    }
                    else
                    {
                        selectedspaceship = 0;
                    }
                }
            }
        }
    
        catch (NullReferenceException erro)
        {
            Debug.Log(erro);
        }
    }

    public void GameOver()
    {
        if (nave0morreu && nave1morreu && nave2morreu || PlanetHP <= 0)
        {
            StartCoroutine("esperaParaAtivaroGameOver");
            AsteroidesNaCena = GameObject.FindGameObjectsWithTag("Asteroide");
            for (int i = 0; i < AsteroidesNaCena.Length; i++)
            {
                AsteroidesNaCena[i].SetActive(false);
            }
        }
    }
    public IEnumerator esperaParaAtivaroGameOver() //Função feita para poder chamar o "WaitForSeconds" E demorar um tempo para o jogador não sofrer muito dao de uma colisão só
    {
        yield return new WaitForSeconds(0.5f);
        popUpGameOver.SetActive(true);
        naveAtivada.gameObject.SetActive(false);
        Time.timeScale = 0f;
        ;
    }

    public void VerificacaoDaNaveSelecionada()
    {
        if (selectedspaceship == 0)
        {
            FireRate = 0.4f;
            armaAtiva = armanave1;
        }
        else if (selectedspaceship == 1)
        {
            ArmazenadorDeFireRateCaca = 0.25f;
            armaAtiva = armanavecaca;
        }
        else if (selectedspaceship == 2)
        {
            FireRate = 0.7f;
            ArmazenadorDeFireRateTanque = 0.7f;
            armaAtiva = armanavetanque;
        }
    }
    
    public void RepararEscudo()
        {
            if (selectedspaceship == 0)
            {
                NaveCaçaScript.escudo += Time.deltaTime;
                NaveTanqueScript.escudo += Time.deltaTime;
            }
            else if (selectedspaceship == 1)
            {
                NaveMediaScript.escudo += Time.deltaTime;
                NaveTanqueScript.escudo += Time.deltaTime;
            }
            else if (selectedspaceship == 2)
            {
                NaveMediaScript.escudo += Time.deltaTime;
                NaveCaçaScript.escudo += Time.deltaTime;
            }
        }
    public IEnumerator esperaparaacabarpowerup() //Função feita para poder chamar o "WaitForSeconds" E demorar um tempo para reestabelecer a velocidade normal após pegar um power down
     {
        yield return new WaitForSeconds(5);
        NaveMediaScript.speed = ArmazenadorDeVelocidade;
        fixpowerup = false;
     }
    public IEnumerator esperaparaacabarpowerupCaca() //Função feita para poder chamar o "WaitForSeconds" E demorar um tempo para reestabelecer a velocidade normal após pegar um power down
    {
        yield return new WaitForSeconds(5);
        NaveCaçaScript.speed = ArmazenadorDeVelocidadeCaca;
        fixpowerupCaca = false;
    }
    public IEnumerator esperaparaacabarpowerupTanque() //Função feita para poder chamar o "WaitForSeconds" E demorar um tempo para reestabelecer a velocidade normal após pegar um power down
    {
        yield return new WaitForSeconds(5);
        NaveTanqueScript.speed = ArmazenadorDeVelocidadeTanque;
        fixpowerupTanque = false;
    }
    public IEnumerator esperaparaacabarpowerupFireRate() //Função feita para poder chamar o "WaitForSeconds" E demorar um tempo para reestabelecer a velocidade de fire rate normal após pegar um power up
     {
        yield return new WaitForSeconds(5);
        FireRate = ArmazenadorDeFireRate;
        armanave1.timeBetweenShots = ArmazenadorDeFireRate;
        fixpoweupFireRate = false;
     }
    public IEnumerator esperaparaacabarpowerupFireRateCaca() //Função feita para poder chamar o "WaitForSeconds" E demorar um tempo para reestabelecer a velocidade de fire rate normal após pegar um power up
    {
        yield return new WaitForSeconds(5);
        FireRate = ArmazenadorDeFireRateCaca;
        armanavecaca.timeBetweenShots = ArmazenadorDeFireRateCaca;
        fixpoweupFireRateCaca = false;
    }
    public IEnumerator esperaparaacabarpowerupFireRateTanque() //Função feita para poder chamar o "WaitForSeconds" E demorar um tempo para reestabelecer a velocidade de fire rate normal após pegar um power up
    {
        yield return new WaitForSeconds(5);
        FireRate = ArmazenadorDeFireRateTanque;
        armanavetanque.timeBetweenShots = ArmazenadorDeFireRateTanque;
        fixpoweupFireRateTanque = false;
    }

    public void SetChildren()
        {
            NaveTanque.transform.SetParent(gerenciadorDeNaves.transform);
        }
}






