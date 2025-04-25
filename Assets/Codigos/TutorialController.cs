using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject asteroides;
    public Vector3 spawnValues;
    public int asteroidesCount; // quantos asteroides vem na wave   
    public float spawnWait; // tempo de um asteroide para o outro
    public float startWait; // tempo no inicio do jogo para o jogador se preparar
    public float waveWait; // tempo de uma wave para a outra

    public float timer;
    public float tempoWavePraOutra;

    void Start()
    {
        StartCoroutine("SpawnWaves");
    }

    IEnumerator SpawnWaves() // gerador de waves de asteroides
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < asteroidesCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-1.5f, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroides, spawnPosition, spawnRotation);


                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
