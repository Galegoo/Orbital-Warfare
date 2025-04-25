using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed;

    public float posicaoDestinoX;
    public float posicaoDestinoY;


    private Vector3 movementVector = Vector3.zero;
    private Vector3 posicaoDestino;

    void Start()
    {
        posicaoDestino = new Vector3(Random.Range(-posicaoDestinoX, posicaoDestinoX), Random.Range(-posicaoDestinoY, posicaoDestinoY), -15);
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


