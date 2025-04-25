using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupsMovement : MonoBehaviour { 
    public float speed;

    public float posicaoDestinoX;
    public float posicaoDestinoY;
    public float posicaoDestinoZ;

    GameObject gerenciadorDeNaves;
    public SpaceShip naveAtiva;
    private Vector3 posNaveActiva;

    private Vector3 movementVector = Vector3.zero;
    private Vector3 posicaoDestino;


    void Start() {
        gerenciadorDeNaves = GameObject.Find("Gerenciador de naves");
        naveAtiva = gerenciadorDeNaves.GetComponentInChildren<SpaceShip>();
        posNaveActiva = naveAtiva.transform.position;

        posicaoDestino = new Vector3(Random.Range(-posicaoDestinoX + posNaveActiva.x, posicaoDestinoX + posNaveActiva.x), Random.Range(-posicaoDestinoY + posNaveActiva.y, posicaoDestinoY + posNaveActiva.y), posicaoDestinoZ);
        movementVector = (posicaoDestino - transform.position).normalized * speed;

    }

    private void Update() {
        if (speed != 0) {
            if (this.transform.position.z > -10)
                this.transform.position += movementVector * Time.deltaTime;
            else
                Destroy(this.gameObject);
        } else
            Debug.Log("No speed");
    }
}

