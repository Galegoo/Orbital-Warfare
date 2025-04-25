using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilNavePrincipal : MonoBehaviour
{
    public float speed; //velocidade da bala
    public float viewDistance; //distancia max da bala
    public float missilDamage;
    private EnemyShip enemy;

    public GameObject[] navesInimigas;
    private GameObject naveAlvo;
    private Vector3 posNaveInimiga;
    private Vector3 posAux;
    private Vector3 movementVector = Vector3.zero;

    public SelectedShip selected;
    GameObject gerenciadorDeNavess;


    // Start is called before the first frame update
    void Start() {
        gerenciadorDeNavess = GameObject.Find("Gerenciador de naves");
        selected = gerenciadorDeNavess.GetComponentInChildren<SelectedShip>();
        selected.specialShotSound.Play();
        randomizeEnemyTarget();
    }

    // Update is called once per frame
    void Update() {
        if (naveAlvo != null) {
            posNaveInimiga = naveAlvo.transform.position;
            movementVector = (posNaveInimiga - transform.position).normalized * speed;
            //posAux = posNaveInimiga;
        } 
        else {
            randomizeEnemyTarget();
            //movementVector = (posAux - transform.position).normalized * speed;
            //Debug.Log("qwerty");
            
        }
            

        this.transform.position += movementVector * Time.deltaTime;
        if (this.transform.position.z > 200)
          this.gameObject.SetActive(false);
        
    }

    private void randomizeEnemyTarget() {
        navesInimigas = GameObject.FindGameObjectsWithTag("naveInimiga");
        if (navesInimigas.Length > 0) {
            naveAlvo = navesInimigas[Random.Range(0, navesInimigas.Length - 1)];
        }

    }

    private void OnCollisionEnter(Collision col) {

        float hpAtual = col.gameObject.GetComponent<EnemyShip>().NaveInimigaHP;

        if (col.gameObject.tag == "Asteroide") {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "naveInimiga") {
            selected.EnemyDeathSound.Play();
            hpAtual -= missilDamage;
            Destroy(this.gameObject);
            if (hpAtual <= 0) {
                Destroy(col.gameObject);
            }
            
        }
    }
}
