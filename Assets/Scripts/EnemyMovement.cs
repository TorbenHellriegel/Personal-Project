using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float horizontalSpeed = 10;
    public float movementDirection = 1;
    private float movementBorder = 70;

    // Start is called before the first frame update
    void Start()
    {
        movementDirection = (Random.Range(0, 2) - 0.5f) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Move enemy left and right
        transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * movementDirection);

        // Stop the enemy from moving too far
        if(transform.position.x < - movementBorder)
        {
            transform.position = new Vector3(-movementBorder, transform.position.y, transform.position.z);
            movementDirection = movementDirection * -1;
        }
        if(transform.position.x > movementBorder)
        {
            transform.position = new Vector3(movementBorder, transform.position.y, transform.position.z);
            movementDirection = movementDirection * -1;
        }
        
    }
}
