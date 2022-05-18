using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables for enemy movement
    public float horizontalSpeed = 10;
    private float moveInSpeed = 5;
    public float movementDirection = 1;
    private float movementBorderX = 70;
    private float movementBorderZ = 40;

    // Variables for shooting
    public GameObject projectile;
    public float shootingSpeed = 0.5f;
    public float shootingDelay = 2;
    public int multiShot = 1;
    
    // Variables for enemy health
    public float maxHealth = 3;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        movementDirection = (Random.Range(0, 2) - 0.5f) * 2;

        currentHealth = maxHealth;

        // Start shooting after a short delay
        if(multiShot == 1)
        {
            Invoke("Shoot", shootingDelay);
        }
        else
        {
            Invoke("ShootMulti", shootingDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the enemy into the right position after spawning
        if(transform.position.z > movementBorderZ)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveInSpeed);
        }
        else
        {
            // Move enemy left and right
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed * movementDirection);
        }

        // Stop the enemy from moving too far
        if(transform.position.x < - movementBorderX)
        {
            transform.position = new Vector3(-movementBorderX, transform.position.y, transform.position.z);
            movementDirection = movementDirection * -1;
        }
        if(transform.position.x > movementBorderX)
        {
            transform.position = new Vector3(movementBorderX, transform.position.y, transform.position.z);
            movementDirection = movementDirection * -1;
        }
    }

    // Repetedly shoots projectiles
    private void Shoot()
    {
        Instantiate(projectile, transform.position + Vector3.back*3, transform.rotation);
        Invoke("Shoot", shootingSpeed);
    }

    // Repetedly shoots multiple projectiles
    private void ShootMulti()
    {
        for(int i = 0; i < multiShot; i++)
        {
            float angle = -30 + i * 60/(multiShot-1);
            Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, angle, 0));
        }
        Invoke("ShootMulti", shootingSpeed);
    }

    // Checks for collisions with projectiles
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("playerShot"))
        {
            loseHealth(1);
        }
    }

    // Loses health when hit by projectile
    private void loseHealth(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
