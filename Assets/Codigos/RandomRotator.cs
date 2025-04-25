using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;
    public Rigidbody rb;
    void Start()
    {
        //GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        rb = GetComponent<Rigidbody>();
    }

// Update is called once per frame
void Update ()
    {
		rb.angularVelocity = new Vector3(0, 1 * tumble, 0);
    }
}
