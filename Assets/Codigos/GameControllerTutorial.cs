using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerTutorial : MonoBehaviour
{
    public GameObject[] asteroidespequenos;
    public GameObject[] asteroidesGrandes;
    public GameObject CaixaDialogo;
    public GameObject CaixaDialogo2;
    public GameObject CaixaDialogo3;
    public DialogueManager dialoguemanager2;
    public DialogueManager dialoguemanager3;
    public Dialogo dialogo2;
    public Dialogo dialogo3;

    public void Start()
    {
        dialoguemanager2 = CaixaDialogo2.GetComponent<DialogueManager>();
        dialoguemanager3 = CaixaDialogo3.GetComponent<DialogueManager>();
    }

    public void SpawnTutorial() { 

                for (int i = 0; i < asteroidespequenos.Length; i++)
                {
                    asteroidespequenos[i].gameObject.SetActive(true);
                    StartCoroutine("esperaProximoDialogo");
                }
    }
    public void SpawnTutorial2()
    {

        for (int i = 0; i < asteroidesGrandes.Length; i++)
        {
            asteroidesGrandes[i].gameObject.SetActive(true);
            StartCoroutine("esperaProximoDialogo2");
        }
    }

    public IEnumerator esperaProximoDialogo()
    {
        yield return new WaitForSeconds(15);
        CaixaDialogo2.gameObject.SetActive(true);
        dialoguemanager2.StartDialogo2(dialogo2);

    }
    public IEnumerator esperaProximoDialogo2()
    {
        yield return new WaitForSeconds(15);
        CaixaDialogo3.gameObject.SetActive(true);
        dialoguemanager3.StartDialogo3(dialogo3);

    }
}
