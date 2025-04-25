using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax; 
}

public class SpaceShip : MonoBehaviour
{
    
    public float speed;
    public float tilt;
    public float healthpoints;
    public float escudo;
    public float maxShield;
    public float maxHealth;
    public float maxSpeed;

    public Boundary boundary;
    public Rigidbody rb;

    GameObject ReferenciagerenciadorDeNaves;

    public float cooldownweapon2;
    public float cooldownweapon2Max;
    public Weapon2 referenciaweapon2;
    public Weapon2Tanque referenciaweapon2tanque;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        ReferenciagerenciadorDeNaves = GameObject.Find("Gerenciador de naves");
    }
    void FixedUpdate()
    {
        //recebe valores de acordo com a tecla pressionada para aplicar a movimentação
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //movimentação
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        rb.velocity = movement * speed;

        //determina até onde a nave pode ir na tela
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            -5f
        );

        //rotaciona quando acelera
        rb.rotation = Quaternion.Euler(rb.velocity.y * -tilt, 0, rb.velocity.x * -tilt);
        //manter os valores até seu maximo e minimo, para que upgrades nem interações façam o seu valor ultrapassar o limite
        if (escudo > maxShield)
        {
            escudo = maxShield;
        }
        if (healthpoints > maxHealth)
            healthpoints = maxHealth;
        if (escudo < 0)
        {
            escudo = 0;
        }
        if (healthpoints < 0)
            healthpoints = 0;
    }
    public void Update()
    {
        /* referenciaweapon2 = GetComponentInChildren<Weapon2>();
         referenciaweapon2tanque = GetComponentInChildren<Weapon2Tanque>();
         if (referenciaweapon2 == null)
         {
             cooldownweapon2 = referenciaweapon2.coolDownTimer;
             cooldownweapon2Max = referenciaweapon2.coolDown;
         }
         else
         {
             cooldownweapon2 = referenciaweapon2tanque.coolDownArma;
             cooldownweapon2Max = referenciaweapon2tanque.coolDownArmaMax;
         }
     }*/
    }
    
}


