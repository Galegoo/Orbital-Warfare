using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVolta : MonoBehaviour
{
    public float speed;
    public GameObject[] particulas;
    public float limite;
    private Vector3 posicaoInicial;

    // Start is called before the first frame update
    void Start()
    {
        //particulas[0].SetActive(true);
        particulas[1].SetActive(false);
        particulas[2].SetActive(false);
        posicaoInicial = particulas[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (particulas[0].transform.position.z >= limite)
        {
            particulas[0].transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
        }
        if(particulas[0].transform.position.z <= limite + 10)
        {
            particulas[1].transform.position = posicaoInicial;
            particulas[1].SetActive(true);
        }
        else if (particulas[0].transform.position.z <= limite)
        {
            particulas[0].SetActive(false);
            particulas[0].transform.position = posicaoInicial;
            //particulas[2].transform.position = posicaoInicial;
        }
        if (particulas[1].transform.position.z >= limite)
        {
            particulas[1].transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
        }
        if (particulas[1].transform.position.z <= limite + 10)
        {
            particulas[2].transform.position = posicaoInicial;
            particulas[2].SetActive(true);
        }
        else if (particulas[1].transform.position.z <= limite)
        {
            particulas[1].SetActive(false);
            particulas[1].transform.position = posicaoInicial;
           // particulas[0].transform.position = posicaoInicial;
        }
        if (particulas[2].transform.position.z >= limite)
        {
            particulas[2].transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
        }
        if (particulas[2].transform.position.z <= limite + 10)
        {
            particulas[0].transform.position = posicaoInicial;
            particulas[0].SetActive(true);
        }
        else if (particulas[2].transform.position.z <= limite)
        {
            particulas[2].SetActive(false);
            //particulas[1].transform.position = posicaoInicial;
            particulas[2].transform.position = posicaoInicial;
        }
    }
}
