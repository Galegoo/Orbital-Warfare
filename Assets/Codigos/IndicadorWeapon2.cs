using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class IndicadorWeapon2 : MonoBehaviour
{

    public Image secondWeaponbarMedia;
    public Image secondWeaponbarCaca;
    public Image secondWeaponbarTanque;
    public static float secondWeaponMediaFloat;
    public static float secondWeaponCacaFloat;
    public static float secondWeaponTanqueFloat;
    public Weapon2NavePrincipal secondWeaponMediaScript;
    public Weapon2 secondWeaponCacaScript;
    public Weapon2Tanque secondWeaponTanqueScript;

    private void Start() {
        secondWeaponbarMedia = GameObject.Find("IndicadorSecondWeaponBarHudNaveMedia").GetComponent<Image>();
        secondWeaponbarCaca = GameObject.Find("IndicadorSecondWeaponBarHudNaveCaca").GetComponent<Image>();
        secondWeaponbarTanque = GameObject.Find("IndicadorSecondWeaponBarHudNaveTanque").GetComponent<Image>();
        secondWeaponMediaFloat = secondWeaponMediaScript.misseisDisponiveis;
        secondWeaponCacaFloat = secondWeaponCacaScript.coolDown;
        secondWeaponTanqueFloat = secondWeaponTanqueScript.coolDownArma;
    }

    // Update is called once per frame
    void Update() {
        try {
            secondWeaponMediaFloat = secondWeaponMediaScript.misseisDisponiveis;
            secondWeaponCacaFloat = secondWeaponCacaScript.coolDownTimer;
            secondWeaponTanqueFloat = secondWeaponTanqueScript.coolDownArma;
            secondWeaponbarMedia.fillAmount = secondWeaponMediaFloat / secondWeaponMediaScript.MaxMisseis;
            secondWeaponbarCaca.fillAmount = secondWeaponCacaFloat / secondWeaponCacaScript.coolDown;
            secondWeaponbarTanque.fillAmount = secondWeaponTanqueFloat / secondWeaponTanqueScript.coolDownArmaMax;

        } catch (NullReferenceException e) {
            Debug.Log(e);
        }
    }
}
