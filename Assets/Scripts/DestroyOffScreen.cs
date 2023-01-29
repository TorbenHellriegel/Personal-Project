using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private float destructionBorderX = 90;
    private float destructionBorderz = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy when leaving the screen
        if(transform.position.x < -destructionBorderX
        || transform.position.x > destructionBorderX
        || transform.position.z < -destructionBorderz
        || transform.position.z > destructionBorderz)
        {
            gameObject.SetActive(false);
        }
    }
}
