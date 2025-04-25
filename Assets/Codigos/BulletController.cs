using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public float speed; //velocidade da bala
    public float viewDistance; //distancia max da bala

    GameObject gerenciadorDeNaves;
    public SpaceShip naveAtiva;
    public SelectedShip selected;
    private GameObject objetoAlvo;
    private GameObject objetoAlvoAux;
    private Vector3 hitPosition;
    private Vector3 hitPositionAux;

    

    private Vector3 movementVector = Vector3.zero;
    // Start is called before the first frame update
    void Start() {
        //encontrar nave ativa
        gerenciadorDeNaves = GameObject.Find("Gerenciador de naves");
        selected = gerenciadorDeNaves.GetComponent<SelectedShip>();
        naveAtiva = gerenciadorDeNaves.GetComponentInChildren<SpaceShip>();

        hitPositionAux = naveAtiva.transform.Find("Gun").GetChild(0).GetComponent<RotateToMouse>().rayMouse.GetPoint(naveAtiva.transform.Find("Gun").GetChild(0).GetComponent<RotateToMouse>().maxLenght);
        //
        //encontrar objeto em que o rato clica
        if (naveAtiva.transform.Find("Gun").GetChild(0).GetComponent<RotateToMouse>().atingeObjecto) {
            objetoAlvoAux = naveAtiva.transform.Find("Gun").GetChild(0).GetComponent<RotateToMouse>().hit.collider.gameObject;
            if (objetoAlvoAux.tag == "naveInimiga" || objetoAlvoAux.tag == "Asteroide" || objetoAlvoAux.tag == "naveInimigaCaca")
                objetoAlvo = naveAtiva.transform.Find("Gun").GetChild(0).GetComponent<RotateToMouse>().hit.collider.gameObject;
            //vector3 da posicao do objeto clicado
            //hitPosition = objetoAlvo.transform.position;
            //movementVector = (hitPosition - transform.position).normalized * speed;
        } else {
            movementVector = (hitPositionAux - transform.position).normalized * speed;
        }
    }

    // Update is called once per frame
    void Update() {
        if (objetoAlvo != null) {
            hitPosition = objetoAlvo.transform.position;
            movementVector = (hitPosition - transform.position).normalized * speed;
            
        } else {
            movementVector = (hitPositionAux - transform.position).normalized * speed;

        }

        this.transform.position += movementVector * Time.deltaTime;

        if (this.transform.position.z > 200)
            Destroy(this.gameObject);
    }

}
