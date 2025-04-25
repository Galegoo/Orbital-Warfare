using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Image healthBar;
    public Image shieldBar;
    public Image planetBar;

    public Image healthBarNaveMediaHud;
    public Image shieldBarNaveMediaHud;

    public Image healthBarNaveCacaHud;
    public Image shieldBarNaveCacaHud;

    public Image healthBarNaveTanqueHud;
    public Image shieldBarNaveTanqueHud;


    public static float shieldNaveMedia;
    public static float healthNaveMedia;

    public static float shieldNaveCaca;
    public static float healthNaveCaca;

    public static float shieldNaveTanque;
    public static float healthNaveTanque;

    public static float health;
    public static float shield;
    public static float planet;
    //public static float secondWeapon;
    GameObject gerenciaNaves;
    public SpaceShip naveAtivada;
    public SelectedShip referenciaprahpplaneta;

    // Start is called before the first frame update
    void Awake() {
        gerenciaNaves = GameObject.Find("Gerenciador de naves");
        naveAtivada = gerenciaNaves.GetComponentInChildren<SpaceShip>();
        referenciaprahpplaneta = gerenciaNaves.GetComponent<SelectedShip>();
    }

    private void Start() {
        healthBar = GetComponent<Image>();
        shieldBar = GameObject.Find("ShieldBar").GetComponent<Image>();
        planetBar = GameObject.Find("PlanetBar").GetComponent<Image>();
        healthBarNaveMediaHud = GameObject.Find("HealthBarHudNaveMedia").GetComponent<Image>();
        shieldBarNaveMediaHud = GameObject.Find("ShieldBarHudNaveMedia").GetComponent<Image>();
        healthBarNaveCacaHud = GameObject.Find("HealthBarHudNaveCaca").GetComponent<Image>();
        shieldBarNaveCacaHud = GameObject.Find("ShieldBarHudNaveCaca").GetComponent<Image>();
        healthBarNaveCacaHud = GameObject.Find("HealthBarHudNaveTanque").GetComponent<Image>();
        shieldBarNaveTanqueHud = GameObject.Find("ShieldBarHudNaveTanque").GetComponent<Image>();
        //secondWeaponbar = GameObject.Find("SecondWeaponBar").GetComponent<Image>();
        planet = referenciaprahpplaneta.PlanetHP;
        health = naveAtivada.maxHealth;
        shield = naveAtivada.maxShield;
        //secondWeapon = naveAtivada.cooldownweapon2Max;

    }

    // Update is called once per frame
    void Update() {
        try {
            naveAtivada = gerenciaNaves.GetComponentInChildren<SpaceShip>();
            health = naveAtivada.healthpoints;
            shield = naveAtivada.escudo;
            healthNaveMedia = referenciaprahpplaneta.NaveMediaScript.healthpoints;
            shieldNaveMedia = referenciaprahpplaneta.NaveMediaScript.escudo;
            healthNaveCaca = referenciaprahpplaneta.NaveCaçaScript.healthpoints;
            shieldNaveCaca = referenciaprahpplaneta.NaveCaçaScript.escudo;
            healthNaveTanque = referenciaprahpplaneta.NaveTanqueScript.healthpoints;
            shieldNaveTanque = referenciaprahpplaneta.NaveTanqueScript.escudo;
            // secondWeapon = naveAtivada.cooldownweapon2;
            healthBar.fillAmount = health / naveAtivada.maxHealth;
            shieldBar.fillAmount = shield / naveAtivada.maxHealth;
            healthBarNaveMediaHud.fillAmount = healthNaveMedia / referenciaprahpplaneta.NaveMediaScript.maxHealth;
            shieldBarNaveMediaHud.fillAmount = shieldNaveMedia / referenciaprahpplaneta.NaveMediaScript.maxShield;
            healthBarNaveCacaHud.fillAmount = healthNaveCaca / referenciaprahpplaneta.NaveCaçaScript.maxHealth;
            shieldBarNaveCacaHud.fillAmount = shieldNaveCaca / referenciaprahpplaneta.NaveCaçaScript.maxShield;
            healthBarNaveCacaHud.fillAmount = healthNaveTanque / referenciaprahpplaneta.NaveTanqueScript.maxHealth;
            shieldBarNaveTanqueHud.fillAmount = shieldNaveTanque / referenciaprahpplaneta.NaveTanqueScript.maxShield;
        } catch (NullReferenceException e) {
            Debug.Log(e);
        }
        planet = referenciaprahpplaneta.PlanetHP;
        planetBar.fillAmount = planet / referenciaprahpplaneta.maxPlanetHP;
        // secondWeaponbar.fillAmount = secondWeapon / naveAtivada.cooldownweapon2Max;
    }
}
