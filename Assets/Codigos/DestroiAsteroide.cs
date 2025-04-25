using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiAsteroide : MonoBehaviour {
    public float asteroideHP;
    public float maximoz; // ponto de destruição dos asteroides
    public float maximotamanho; //tamanho maximo do asteroide
    public float minimotamanho; //tamanho maximo do asteroide
    // Update is called once per frame
    private void Start()
    {
        //CAlcular tamanho e volume do asteroide
        float x = Random.Range(maximotamanho, minimotamanho);
        float y = Random.Range(maximotamanho, minimotamanho);
        float z = Random.Range(maximotamanho, minimotamanho);
        asteroideHP = (x * y * z) * 50;

        this.gameObject.transform.localScale = new Vector3(x, y, z);
    }
    void Update () {
        //destroi o asteroide depois que ele passa da pozição em z determinada
		if(this.gameObject.transform.position.z < maximoz)
        {
            Destroy(this.gameObject);
        }
        
	}

    
}
