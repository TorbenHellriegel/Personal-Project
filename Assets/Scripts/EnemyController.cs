using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables for enemy movement
    public float horizontalSpeed = 10;
    public float movementDirection = 1;
    private float movementBorder = 70;

    // Variables for shooting
    public GameObject projectile;
    public float shootingSpeed = 0.5f;
    public int multiShot = 1;
    
    // Variables for enemy health
    public float maxHealth = 3;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        movementDirection = (Random.Range(0, 2) - 0.5f) * 2;

        currentHealth = maxHealth;

        if(multiShot == 1)
        {
            Invoke("Shoot", shootingSpeed);
        }
        else
        {
            Invoke("ShootMulti", shootingSpeed);
        }
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
