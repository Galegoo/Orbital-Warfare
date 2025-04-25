using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorDeDialogo : MonoBehaviour
{
    public Dialogo dialogo;


    public void AtivadorDialogo()
    {
        FindObjectOfType<DialogueManager>().StartDialogo(dialogo);
    }
}
