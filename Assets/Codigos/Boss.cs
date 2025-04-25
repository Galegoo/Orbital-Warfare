using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Boss : MonoBehaviour
{
    public bool abre = false;
    public bool Idle;
    public Animator AnimatorBoss;
    public float EsperaPraMover;
    public float EsperaPraMoverMax;
    public float localizacaoNum;
    public float ultimaLoc;
    public GameObject[] wayPoints;
    public float speed;
    public float TempoAberto;

    public SpaceShip Ativa;
    public GameObject gerenciador;
    public GunController arma;
    public Weapon2 arma2;
    public float bossHp;
    public float bossHpMax;
    public float bossShield;
    public float bossShieldMax;
    public float danoArma1;
    public Image HPbar;
    public Image SPbar;


    // Start is called before the first frame update
    void Start()
    {
        HPbar = GameObject.Find("HealthBarBoss").GetComponent<Image>();
        SPbar = GameObject.Find("ShieldBarBoss").GetComponent<Image>();
        bossHpMax = bossHp;
        bossShieldMax = bossShield;
        EsperaPraMoverMax = EsperaPraMover;
        AnimatorBoss = GetComponent<Animator>();
        AnimatorBoss.SetBool("Abre", abre);
        localizacaoNum = UnityEngine.Random.Range(1, wayPoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            HPbar.fillAmount = bossHp / bossHpMax;
            SPbar.fillAmount = bossShield / bossShieldMax;
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
        Ativa = gerenciador.GetComponentInChildren<SpaceShip>();
        arma = Ativa.transform.Find("Gun").GetComponent<GunController>();
        AnimatorBoss.SetBool("Abre", abre);
        AnimatorBoss.SetBool("Idle", Idle);
        if (abre == true)
        {
            StartCoroutine("Abreai");
        }
        EsperaPraMover -= Time.deltaTime;
        if (EsperaPraMover <= 0)
        {
            Movimentacao();
        }
    }
    public void Movimentacao()
    {
        ultimaLoc = localizacaoNum;

        if (localizacaoNum == 1)
        {
            if (this.transform.position != wayPoints[1].transform.position)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, wayPoints[1].transform.position, Time.deltaTime * speed);
            }
            else if (this.transform.position == wayPoints[1].transform.position)
            {
                EsperaPraMover = EsperaPraMoverMax;
                while (localizacaoNum == ultimaLoc)
                {
                    localizacaoNum = UnityEngine.Random.Range(1, wayPoints.Length);
                }
            }
        }
        else if (localizacaoNum == 2)
        {
            if (this.transform.position != wayPoints[2].transform.position)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, wayPoints[2].transform.position, Time.deltaTime * speed);
            }
            else if (this.transform.position == wayPoints[2].transform.position)
            {
                EsperaPraMover = EsperaPraMoverMax;
                while (localizacaoNum == ultimaLoc)
                {
                    localizacaoNum = UnityEngine.Random.Range(1, wayPoints.Length);
                }
            }
        }
        else if (localizacaoNum == 3)
        {
            if (this.transform.position != wayPoints[3].transform.position)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, wayPoints[3].transform.position, Time.deltaTime * speed);
            }
            else if (this.transform.position == wayPoints[3].transform.position)
            {
                EsperaPraMover = EsperaPraMoverMax;
                while (localizacaoNum == ultimaLoc)
                {
                    localizacaoNum = UnityEngine.Random.Range(1, wayPoints.Length);
                }
            }
        }
        else if (localizacaoNum == 4)
        {
            if (this.transform.position != wayPoints[4].transform.position)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, wayPoints[4].transform.position, Time.deltaTime * speed);
            }
            else if (this.transform.position == wayPoints[4].transform.position)
            {
                EsperaPraMover = EsperaPraMoverMax;
                while (localizacaoNum == ultimaLoc)
                {
                    localizacaoNum = UnityEngine.Random.Range(1, wayPoints.Length);
                }
            }
        }
        else if (localizacaoNum == 5)
        {
            if (this.transform.position != wayPoints[5].transform.position)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, wayPoints[5].transform.position, Time.deltaTime * speed);
            }
            else if (this.transform.position == wayPoints[5].transform.position)
            {
                EsperaPraMover = EsperaPraMoverMax;
                while (localizacaoNum == ultimaLoc)
                {
                    localizacaoNum = UnityEngine.Random.Range(1, wayPoints.Length);
                }
            }
        }

    }
    public IEnumerator Abreai()
    {
        yield return new WaitForSeconds(TempoAberto);
        abre = false;
        yield return new WaitForSeconds(2.5f);
        Idle = true;
        bossShield = bossShieldMax;
        StopCoroutine("Abreai");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bala")
        {
            danoArma1 = arma.bulletDamage;
            Dano();
            Destroy(other);

        }
        else if (other.gameObject.tag == "MissilNaveCaca")
        {
            danoArma1 = arma2.bulletDamage;
            Dano();
            Destroy(other);
        }
    }
    public void Dano()
    {
        if (abre)
        {
            bossHp -= danoArma1;
        }
        else
        {
            if (bossShield >= 0)
            {
                bossShield -= danoArma1;
            }
            else if (bossShield <= 0)
            {
                abre = true;
                Idle = false;
            }
        }
    }
}
