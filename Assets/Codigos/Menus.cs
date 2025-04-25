using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelecaoDeNiveis()
    {
        SceneManager.LoadScene("SelecaoNiveis");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void nivel1()
    {
        SceneManager.LoadScene("Cena Sample");
    }
    public void MenuPrincial()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}
