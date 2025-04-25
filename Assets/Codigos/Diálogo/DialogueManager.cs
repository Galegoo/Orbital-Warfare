using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogoText;

    public string[] NomeNPC;
    public Dialogo dialogo;

    public GameControllerTutorial gamecontrollertutorial;
    public SelectedShip referenciaSelectedShip;

    private Queue<string> sentences;


    void Start()
    {
        referenciaSelectedShip = GameObject.Find("Gerenciador de naves").GetComponent<SelectedShip>();
        sentences = new Queue<string>();
        StartDialogo(dialogo);
    }

    public void DisplayNextSentence()
    {
        Debug.Log(sentences.Count);
        if (sentences.Count == 12 || sentences.Count == 10 || sentences.Count == 7 || sentences.Count == 5 || sentences.Count == 3)
        {
            nameText.text = NomeNPC[0];
        }
        else
        {
            nameText.text = NomeNPC[1];

        }
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogoText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogoText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        gamecontrollertutorial.SpawnTutorial();
        gamecontrollertutorial.CaixaDialogo.SetActive(false);
    }

    public void StartDialogo(Dialogo dialogo)
    {
        nameText.text = NomeNPC[0];
        sentences.Clear();

        foreach (string sentence in dialogo.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void StartDialogo2(Dialogo dialogo2)
    {
        sentences.Clear();

        foreach (string sentence in dialogo2.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence2();
    }
    public void DisplayNextSentence2()
    {
        Debug.Log(sentences.Count);
        if (sentences.Count == 8 || sentences.Count == 6 || sentences.Count == 4 ||  sentences.Count == 0 || sentences.Count == 10 || sentences.Count == 1)
        {
            nameText.text = NomeNPC[0];
        }
        else
        {
            nameText.text = NomeNPC[1];

        }
        if (sentences.Count == 6)
        {
            referenciaSelectedShip.SetChildren();
            referenciaSelectedShip.naveAtivada.gameObject.SetActive(false);
            referenciaSelectedShip.NaveTanque.gameObject.SetActive(true);

        }
        if (sentences.Count == 0)
        {
            Debug.Log("entrou");
            EndDialogue2();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    void EndDialogue2()
    {
        gamecontrollertutorial.SpawnTutorial2();
        gamecontrollertutorial.CaixaDialogo2.SetActive(false);
    }
    public void StartDialogo3(Dialogo dialogo2)
    {
        nameText.text = NomeNPC[0];
        sentences.Clear();

        foreach (string sentence in dialogo2.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence3();
    }
    public void DisplayNextSentence3()
    {
        Debug.Log(sentences.Count);

        if (sentences.Count == 12 || sentences.Count == 9 || sentences.Count == 7 || sentences.Count == 3 || sentences.Count == 1 || sentences.Count == 0)
        {
            nameText.text = NomeNPC[0];
        }
        else if(sentences.Count == 5 || sentences.Count == 6)
        {
            nameText.text = NomeNPC[2];

        }
        else
        {
            nameText.text = NomeNPC[1];
        }
        if (sentences.Count == 0)
        {
            Debug.Log("entrou");
            EndDialogue3();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    void EndDialogue3()
    {
        SceneManager.LoadScene("Cena Sample");
    }
}
