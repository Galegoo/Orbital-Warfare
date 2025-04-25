using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PopUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pause()
    {
        PopUp.SetActive(true);
        Time.timeScale = 0;
    }
    public void continuar()
    {
        PopUp.SetActive(false);
        Time.timeScale = 1;
    }
    public void voltarParaOMenu()
    {
        SceneManager.LoadScene("Menu Principal");
    }
    public void retry()
    {
        SceneManager.LoadScene("Cena Sample");
    }
}
