using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOffWall : MonoBehaviour
{
    private GameObject player;
    public float speed = 30;
    private Vector3 moveDirection;
    private float botomWallZ = -40;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        moveDirection = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * Time.deltaTime * speed);

        // Change direction when hitting the bottom
        if(transform.position.z < botomWallZ)
        {
            // Calculate the new move direction
            moveDirection = (transform.position - player.transform.position).normalized;
        }
    }
}
