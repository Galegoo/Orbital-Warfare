using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteracaoNavePowerup : MonoBehaviour
{
    public SpaceShip naveAtiva;
    public SelectedShip selectedShip;
    GameObject gerenciadorDeNaves;
    public float maximoZ;

    public float MinPW_ShieldUp;
    public float MaxPW_ShieldUp;

    public float MinPW_HealthUp;
    public float MaxPW_HealthUp;

    private GameObject parent;

    public float PW_FireRateUp;
    public float MinPW_AccelDown;
    public float MaxPW_AccelDown;

    private bool podeColidir = true;

    // Use this for initialization
    void Awake()
    {
        gerenciadorDeNaves = GameObject.Find("Gerenciador de naves");
        selectedShip = GameObject.Find("Gerenciador de naves").GetComponent<SelectedShip>();
    }

    // Update is called once per frame
    void Update()
    {
        naveAtiva = gerenciadorDeNaves.GetComponentInChildren<SpaceShip>();


        //destroi o powerup depois que ele passa da pozição em z determinada
        if (this.gameObject.transform.position.z < maximoZ)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {

        if (podeColidir)
        {
            if (col.gameObject.tag == "nave")
            {
                selectedShip.PowerUpPickUpSound.Play();
                Debug.Log("powerup");

                if (this.gameObject.tag == "PW_Shield+")
                {

                    if (naveAtiva.escudo < naveAtiva.maxShield)
                    {
                        naveAtiva.escudo += naveAtiva.maxShield * Random.Range(MinPW_ShieldUp, MaxPW_ShieldUp);
                        if (naveAtiva.escudo > naveAtiva.maxShield)
                            naveAtiva.escudo = naveAtiva.maxShield;
                    }
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.tag == "PW_Health+")
                {
                    if (naveAtiva.healthpoints < naveAtiva.maxHealth)
                    {
                        naveAtiva.healthpoints += naveAtiva.maxHealth * Random.Range(MinPW_HealthUp, MaxPW_HealthUp);
                        if (naveAtiva.healthpoints > naveAtiva.maxHealth)
                            naveAtiva.healthpoints = naveAtiva.maxHealth;
                    }
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.tag == "PW_Accel-")
                {
                    if (selectedShip.fixpowerup == false)
                    {
                        selectedShip.NaveMediaScript.speed = selectedShip.ArmazenadorDeVelocidade;
                        selectedShip.NaveMediaScript.speed -= selectedShip.NaveMediaScript.maxSpeed * Random.Range(MinPW_AccelDown, MaxPW_AccelDown);
                        selectedShip.fixpowerup = true;
                        Destroy(this.gameObject);
                    }

                }
                else if (this.gameObject.tag == "PW_FireRate+")
                {
                    if (selectedShip.fixpoweupFireRate == false)
                    {
                        selectedShip.FireRate = selectedShip.ArmazenadorDeFireRate;
                        selectedShip.FireRate -= selectedShip.FireRate * PW_FireRateUp;
                        selectedShip.armanave1.timeBetweenShots = selectedShip.FireRate;
                        selectedShip.fixpoweupFireRate = true;
                    }
                    Destroy(this.gameObject);
                }
            }
            else if (col.gameObject.tag == "naveCaca")
            {
                Debug.Log("powerup");
                selectedShip.PowerUpPickUpSound.Play();
                if (this.gameObject.tag == "PW_Shield+")
                {

                    if (naveAtiva.escudo < naveAtiva.maxShield)
                    {
                        naveAtiva.escudo += naveAtiva.maxShield * Random.Range(MinPW_ShieldUp, MaxPW_ShieldUp);
                        if (naveAtiva.escudo > naveAtiva.maxShield)
                            naveAtiva.escudo = naveAtiva.maxShield;
                    }
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.tag == "PW_Health+")
                {
                    if (naveAtiva.healthpoints < naveAtiva.maxHealth)
                    {
                        naveAtiva.healthpoints += naveAtiva.maxHealth * Random.Range(MinPW_HealthUp, MaxPW_HealthUp);
                        if (naveAtiva.healthpoints > naveAtiva.maxHealth)
                            naveAtiva.healthpoints = naveAtiva.maxHealth;
                    }
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.tag == "PW_Accel-")
                {
                    if (selectedShip.fixpowerupCaca == false)
                    {
                        selectedShip.NaveCaçaScript.speed = selectedShip.ArmazenadorDeVelocidadeCaca;
                        selectedShip.NaveCaçaScript.speed -= selectedShip.NaveCaçaScript.maxSpeed * Random.Range(MinPW_AccelDown, MaxPW_AccelDown);
                        selectedShip.fixpowerupCaca = true;
                        Destroy(this.gameObject);
                    }

                }
                else if (this.gameObject.tag == "PW_FireRate+")
                {
                    if (selectedShip.fixpoweupFireRateCaca == false)
                    {
                        selectedShip.FireRate = selectedShip.ArmazenadorDeFireRateCaca;
                        selectedShip.FireRate -= selectedShip.armanavecaca.timeBetweenShots * PW_FireRateUp;
                        selectedShip.armanavecaca.timeBetweenShots = selectedShip.FireRate;
                        selectedShip.fixpoweupFireRateCaca = true;
                    }
                    Destroy(this.gameObject);
                }
            }
            else if (col.gameObject.tag == "naveTanque")
            {
                Debug.Log("powerup");
                selectedShip.PowerUpPickUpSound.Play();
                if (this.gameObject.tag == "PW_Shield+")
                {

                    if (naveAtiva.escudo < naveAtiva.maxShield)
                    {
                        naveAtiva.escudo += naveAtiva.maxShield * Random.Range(MinPW_ShieldUp, MaxPW_ShieldUp);
                        if (naveAtiva.escudo > naveAtiva.maxShield)
                            naveAtiva.escudo = naveAtiva.maxShield;
                    }
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.tag == "PW_Health+")
                {
                    if (naveAtiva.healthpoints < naveAtiva.maxHealth)
                    {
                        naveAtiva.healthpoints += naveAtiva.maxHealth * Random.Range(MinPW_HealthUp, MaxPW_HealthUp);
                        if (naveAtiva.healthpoints > naveAtiva.maxHealth)
                            naveAtiva.healthpoints = naveAtiva.maxHealth;
                    }
                    Destroy(this.gameObject);
                }
                else if (this.gameObject.tag == "PW_Accel-")
                {
                    if (selectedShip.fixpowerupTanque == false)
                    {
                        selectedShip.NaveTanqueScript.speed = selectedShip.ArmazenadorDeVelocidadeTanque;
                        selectedShip.NaveTanqueScript.speed -= selectedShip.NaveTanqueScript.maxSpeed * Random.Range(MinPW_AccelDown, MaxPW_AccelDown);
                        selectedShip.fixpowerupTanque = true;
                        Destroy(this.gameObject);
                    }

                }
                else if (this.gameObject.tag == "PW_FireRate+")
                {
                    if (selectedShip.fixpoweupFireRateTanque == false)
                    {
                        selectedShip.FireRate = selectedShip.ArmazenadorDeFireRateTanque;
                        selectedShip.FireRate -= selectedShip.armanavetanque.timeBetweenShots * PW_FireRateUp;
                        selectedShip.armanavetanque.timeBetweenShots = selectedShip.FireRate;
                        selectedShip.fixpoweupFireRateTanque = true;
                    }
                    Destroy(this.gameObject);
                }
            }
            podeColidir = false;
        }

    }
}
