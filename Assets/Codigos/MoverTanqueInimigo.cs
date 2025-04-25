using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTanqueInimigo : MonoBehaviour {

    public float speed;
    public float posicaoDestinoX;

    private float posicaoActualx;
    public GameObject spawnPoint;
    public GameObject NaveInimigaEstatica;
    public float shotCounter;
    public float timeBetweenShots;
    public bool isFiring = true;



    private Vector3 movementVector = Vector3.zero;
    private Vector3 posicaoDestino;



    void Start()
    {
        posicaoDestino = new Vector3(posicaoDestinoX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        movementVector = (posicaoDestino - transform.position).normalized * speed;
    }

    private void Update() {
        posicaoActualx = this.transform.position.x;
        if (speed != 0) {
            if (posicaoActualx > -19)
                this.transform.position += movementVector * Time.deltaTime;
            else
                Destroy(this.gameObject);
        } else
            Debug.Log("No speed");

        
            if (isFiring) {
                shotCounter -= Time.deltaTime;
                
                if (shotCounter <= 0) {
                    shotCounter = timeBetweenShots;
                if (posicaoActualx <= 15) {
                    Debug.Log(posicaoActualx);
                    Vector3 positionEnemy = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(NaveInimigaEstatica, positionEnemy, spawnRotation);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Destroy(collision.gameObject);
    }
}




