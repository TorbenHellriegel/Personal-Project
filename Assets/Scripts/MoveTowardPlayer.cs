using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardPlayer : MonoBehaviour
{
    private GameObject player;
    private Rigidbody enemyRb;

    [SerializeField] private float defaultSpeed = 30;
    public float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
        enemyRb.AddForce(Vector3.back * speed/3, ForceMode.Impulse);
    }

    void OnEnable()
    {
        speed = defaultSpeed;
        enemyRb.AddForce(Vector3.back * speed/3, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // Makes the projectile move towards the player
        Vector3 lookDirection = MoveDirection();
        enemyRb.AddForce(lookDirection * speed);
    }

    // Returns the direction the enemy is supposed to move in
    private Vector3 MoveDirection()
    {
        float lookDirectionX = player.transform.position.x - transform.position.x;
        float lookDirectionZ = player.transform.position.z - transform.position.z;

        return new Vector3(lookDirectionX, 0, lookDirectionZ).normalized;
    }
}
