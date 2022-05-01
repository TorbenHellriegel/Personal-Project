using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float movementBorder = 70;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move Player left and right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * 70);

        // Stop the player from moving too far
        if(transform.position.x < - movementBorder)
        {
            transform.position = new Vector3(-movementBorder, transform.position.y, transform.position.z);
        }
        if(transform.position.x > movementBorder)
        {
            transform.position = new Vector3(movementBorder, transform.position.y, transform.position.z);
        }
    }
}
