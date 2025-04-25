using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Text PlanetHPTexto;

    public Text Textoescudo;
    public Text Textohp;
    public Text TextoScore;
    public Text TextoHiScore;

    private float valorescudo;
    private float valorhp;
    public float Score;
    private float Hiscore;
    public float pontosPorSegundo;

    private bool scoreSubindo = true; // é setado false quando o player morrer para parar o score

    GameObject referenciagerenciadorDeNaves;
    public SpaceShip referencianaveAtiva;
    public SelectedShip scriptPrincipal;

    // Start is called before the first frame update
    void Start()
    {
        referenciagerenciadorDeNaves = GameObject.Find("Gerenciador de naves");
        scriptPrincipal = referenciagerenciadorDeNaves.GetComponent<SelectedShip>();
        if (PlayerPrefs.HasKey("HighScore"))
        {
            Hiscore = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        referencianaveAtiva = referenciagerenciadorDeNaves.GetComponentInChildren<SpaceShip>();
        if (scoreSubindo)
        {
            Score += pontosPorSegundo * Time.deltaTime;
        }
        if (Score >= Hiscore)
        {
            Hiscore = Score;
            PlayerPrefs.SetFloat("HighScore", Hiscore);
        }
        TextoScore.text = "Score: " + Mathf.Round(Score);
        TextoHiScore.text = "High Score: " + Mathf.Round(Hiscore);
        PlanetHPTexto.text = "HP do Planeta: " + Mathf.Round(scriptPrincipal.PlanetHP);
        try
        {
            Textoescudo.text = "Escudo: " + Mathf.Round(referencianaveAtiva.escudo);
            Textohp.text = "HP: " + Mathf.Round(referencianaveAtiva.healthpoints);
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e);
        }
    }
}
