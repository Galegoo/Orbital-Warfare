using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotateToPlayer : MonoBehaviour
{

    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    GameObject gerenciadorDeNaves;
    public SpaceShip naveAtiva;
    
    void Start() {
        gerenciadorDeNaves = GameObject.Find("Gerenciador de naves");
        naveAtiva = gerenciadorDeNaves.GetComponentInChildren<SpaceShip>();
        
    }

    // Update is called once per frame
    void Update() {

        if (naveAtiva != null) {
            naveAtiva = gerenciadorDeNaves.GetComponentInChildren<SpaceShip>();

            //RotateToPlayerDirection(this.gameObject, naveAtiva.transform.position);
        } 
    }

    void RotateToPlayerDirection(GameObject obj, Vector3 destination) {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);

    }

    public Quaternion getRotation() {
        return rotation;
    }

}
