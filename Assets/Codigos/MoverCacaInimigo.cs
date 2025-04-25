using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCacaInimigo : MonoBehaviour {
    public float speed;

    public float posicaoDestinoX;
    public float posicaoDestinoY;


    private Vector3 movementVector = Vector3.zero;
    private Vector3 posicaoDestino;

    private float EsperaPraMover;


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

        /*EsperaPraMover -= Time.deltaTime;
        if (EsperaPraMover <= 0) {
            Movimentacao();
        }*/
    }
}
    
    /*public void Movimentacao() {
        ultimaLoc = localizacaoNum;

        if (localizacaoNum == 1) {
            if (this.transform.position != wayPoints[1].transform.position) {
                this.transform.position = Vector3.MoveTowards(transform.position, wayPoints[1].transform.position, Time.deltaTime * speed);
            } else if (this.transform.position == wayPoints[1].transform.position) {
                EsperaPraMover = EsperaPraMoverMax;
                while (localizacaoNum == ultimaLoc) {
                    localizacaoNum = Random.Range(1, wayPoints.Length);
                }
            }
        } else if (localizacaoNum == 2) {
            if (this.transform.position != wayPoints[2].transform.position) {
                this.transform.position = Vector3.MoveTowards(transform.position, wayPoints[2].transform.position, Time.deltaTime * speed);
            } else if (this.transform.position == wayPoints[2].transform.position) {
                EsperaPraMover = EsperaPraMoverMax;
                while (localizacaoNum == ultimaLoc) {
                    localizacaoNum = Random.Range(1, wayPoints.Length);
                }
            }
        } else if (localizacaoNum == 3) {
            if (this.transform.position != wayPoints[3].transform.position) {
                this.transform.position = Vector3.MoveTowards(transform.position, wayPoints[3].transform.position, Time.deltaTime * speed);
            } else if (this.transform.position == wayPoints[3].transform.position) {
                EsperaPraMover = EsperaPraMoverMax;
                while (localizacaoNum == ultimaLoc) {
                    localizacaoNum = Random.Range(1, wayPoints.Length);
                }
            }
        } else if (localizacaoNum == 4) {
            if (this.transform.position != wayPoints[4].transform.position) {
                this.transform.position = Vector3.MoveTowards(transform.position, wayPoints[4].transform.position, Time.deltaTime * speed);
            } else if (this.transform.position == wayPoints[4].transform.position) {
                EsperaPraMover = EsperaPraMoverMax;
                while (localizacaoNum == ultimaLoc) {
                    localizacaoNum = Random.Range(1, wayPoints.Length);
                }
            }
        } else if (localizacaoNum == 5) {
            if (this.transform.position != wayPoints[5].transform.position) {
                this.transform.position = Vector3.MoveTowards(transform.position, wayPoints[5].transform.position, Time.deltaTime * speed);
            } else if (this.transform.position == wayPoints[5].transform.position) {
                EsperaPraMover = EsperaPraMoverMax;
                while (localizacaoNum == ultimaLoc) {
                    localizacaoNum = Random.Range(1, wayPoints.Length);
                }
            }
        }

    }*/





