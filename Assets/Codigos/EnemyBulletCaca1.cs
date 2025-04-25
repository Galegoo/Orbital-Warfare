using System.Collections;
using System;
using UnityEngine;

public class EnemyBulletCaca1: MonoBehaviour {
    public float speed; //velocidade da bala
    public float viewDistance; //distancia max da bala
    public float enemyBulletDamage;

    GameObject gerenciadorDeNaves;
    public SpaceShip naveAtiva;
    private Vector3 posNaveActiva;

    private Vector3 movementVector = Vector3.zero;

    // Start is called before the first frame update
    void Start() {
        gerenciadorDeNaves = GameObject.Find("Gerenciador de naves"); 
    }

    // Update is called once per frame
    void Update() {
        naveAtiva = gerenciadorDeNaves.GetComponentInChildren<SpaceShip>();
        try {
            posNaveActiva = naveAtiva.transform.position;
        } catch (NullReferenceException e) {
            Debug.Log(e);
        }
        movementVector = (posNaveActiva - transform.position).normalized * speed;
        if (naveAtiva != null) {
            if (speed != 0) {
                if (this.transform.position.z > -10)
                    this.transform.position += movementVector * Time.deltaTime;
                else
                    this.gameObject.SetActive(false);
            } else
                Debug.Log("No speed");
        }
    }

    private void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "Asteroide")
            Destroy(this.gameObject);

        if (col.gameObject.tag == "nave" || col.gameObject.tag == "naveCaca" || col.gameObject.tag == "naveTanque") {

            if (naveAtiva.escudo <= 0) {
                naveAtiva.healthpoints = naveAtiva.healthpoints - enemyBulletDamage;
            } else {

                naveAtiva.escudo = naveAtiva.escudo - enemyBulletDamage;
            }
            Destroy(this.gameObject);
        }
    }
}


