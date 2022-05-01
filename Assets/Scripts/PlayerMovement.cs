using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject cam;

    private float horizontalInput;
    private float horizontalMovementBorder = 70;
    private float verticalMovementBorderTop = 20;
    private float verticalMovementBorderBottom = -40;
    private Vector3 mousePos;
    private float distToCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate distance to vamera to acurately follow the curser on the screen
        distToCamera = cam.transform.position.y - transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Make the player follow the mouse curser
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3( mousePos.x, mousePos.y, distToCamera));
        transform.position = Vector3.Lerp(transform.position, mousePos, 0.3f);

        // Stop the player from moving too far
        if(transform.position.x < - horizontalMovementBorder)
        {
            transform.position = new Vector3(-horizontalMovementBorder, transform.position.y, transform.position.z);
        }
        if(transform.position.x > horizontalMovementBorder)
        {
            transform.position = new Vector3(horizontalMovementBorder, transform.position.y, transform.position.z);
        }
        if(transform.position.z > verticalMovementBorderTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalMovementBorderTop);
        }
        if(transform.position.z < verticalMovementBorderBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalMovementBorderBottom);
        }
    }
}
