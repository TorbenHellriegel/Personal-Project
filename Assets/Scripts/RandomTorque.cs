using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTorque : MonoBehaviour
{
    private Rigidbody objectRb;
    private float maxTorque = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Starts the onject off with a random torque
        objectRb = GetComponent<Rigidbody>();
        objectRb.AddTorque(new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque)), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
