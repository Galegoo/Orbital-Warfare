using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Cria Waves com asteroides e Naves Inimigas
public class GameController : MonoBehaviour {
    
    public Vector3 spawnValues;
    public int asteroidesCount; // quantos asteroides vem na wave   
    public float spawnWait; // tempo de um asteroide para o outro
    public float startWait; // tempo no inicio do jogo para o jogador se preparar
    public float waveWait; // tempo de uma wave para a outra
    public float znave;
    public float numeroWaves;
    public float waveActual;
    public float timer;
    public float tempoWavePraOutra;
    public GameObject NavesInimigas;
    public GameObject NavesInimigasJato;
    public GameObject NavesInimigasTanque;

    public bool temNaveCaca;
    public bool temNaveTanque;

    public GameObject[] teste;



    public GameObject[] TransformHorizontal;
    public GameObject[] TransformVertical;
    public GameObject[] TransformCimaBaixo;

    public GameObject[] asteroidesTipos;

    public bool controle;

    void Start()
    {
        StartCoroutine("SpawnWaves");
        StartCoroutine("SpawnNavesInimigas");
    }
    void Udpate()
    {
        verificacao();
    }
    
    IEnumerator SpawnWaves() // gerador de waves de asteroides
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < asteroidesCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroidesTipos[Random.Range(0, asteroidesTipos.Length)], spawnPosition, spawnRotation);


                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public IEnumerator SpawnNavesInimigas()
    {
        while (true)
        {
            // WAVE N
            if (waveActual == 0) {
                spawnUmaNaveTanque(21);
                controle = false;
                /*spawnUmaNave(2);
                spawnUmaNave(5);
                spawnUmaNaveJato(8);*/
            } else if (waveActual == 1) {
                spawnUmaNave(11);
                spawnUmaNave(12);
                spawnUmaNave(13);
            } else if (waveActual == 2) {
                spawnUmaNaveJato(1);
                spawnUmaNave(7);
                spawnUmaNaveJato(8);
                spawnUmaNave(9);
            } else if (waveActual == 3) {
                spawnUmaNave(3);
                spawnUmaNave(9);
                spawnUmaNave(11);
                spawnUmaNave(17);
            } else if (waveActual == 4) {
                spawnUmaNaveJato(8);
                spawnUmaNaveJato(2);
                spawnUmaNaveJato(10);
                spawnUmaNaveJato(4);
                spawnUmaNaveJato(12);
            } else if (waveActual == 5) {
                spawnUmaNave(1);
                spawnUmaNave(2);
                spawnUmaNave(3);
                spawnUmaNave(4);
                spawnUmaNave(5);
            } else if (waveActual == 6) {
                spawnUmaNave(15);
                spawnUmaNave(9);
                spawnUmaNave(3);
                spawnUmaNave(11);
                spawnUmaNaveJato(16);
                spawnUmaNaveJato(10);
                spawnUmaNaveJato(18);
                spawnUmaNave(19);
            }
            else if(waveActual == 7)
            {
                spawnUmaNaveTanque(21);
                controle = false;
            }
            yield return new WaitForSeconds(tempoWavePraOutra);
            waveActual++;
        }
    }
    void spawnUmaNave(int i) {
        Vector3 positionEnemy = new Vector3(TransformHorizontal[i].transform.position.x, TransformHorizontal[i].transform.position.y, znave);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(NavesInimigas, positionEnemy, spawnRotation);
    }
    void spawnUmaNaveJato(int i) {
        Vector3 positionEnemy = new Vector3(TransformHorizontal[i].transform.position.x, TransformHorizontal[i].transform.position.y, znave);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(NavesInimigasJato, positionEnemy, spawnRotation);
    }
    void spawnUmaNaveTanque(int i)
    {
        Vector3 positionEnemy = new Vector3(TransformHorizontal[i].transform.position.x, TransformHorizontal[i].transform.position.y, TransformHorizontal[i].transform.position.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(NavesInimigasTanque, positionEnemy, spawnRotation);
    }
    public void verificacao()
    {
        if (controle == false)
        {
            try
            {
                teste = GameObject.FindGameObjectsWithTag("naveInimigaCaca");
            }
            catch (System.NullReferenceException e)
            {
                temNaveCaca = false;
            }
            try
            {
                teste = GameObject.FindGameObjectsWithTag("naveInimigaTanque");
            }
            catch (System.NullReferenceException e)
            {

                temNaveTanque = false;
            }

            if(temNaveCaca == false && temNaveTanque == false)
            {
                Debug.Log("ACABOU PORRA");
            }
        }
    }
}

