using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Variables for enemy movement
    private float horizontalSpeed = 10;
    private float moveInSpeed = 5;
    private float movementDirection = 1;
    private float movementBorderX = 70;
    private float movementBorderZ = 40;

    // Variables for shooting
    public GameObject projectile;
    public float shootingSpeed = 0.5f;
    public float bulletSpeed;
    private float shootingDelay = 2;
    public int multiShot = 1;
    
    // Variables for enemy health
    private Slider healthbar;
    public float maxHealth = 3;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponentInChildren<Slider>();

        movementDirection = (Random.Range(0, 2) - 0.5f) * 2;
        currentHealth = maxHealth;
        healthbar.maxValue = maxHealth;
        healthbar.value = currentHealth;
        bulletSpeed = Random.Range(1, 3);

        // Start shooting after a short delay
        if(gameObject.name == "Basic Enemy 3(Clone)")
        {
            Invoke("ShootTracking", shootingDelay);
        }
        else if(gameObject.name == "Basic Enemy 2(Clone)")
        {
            Invoke("ShootBouncy", shootingDelay);
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
    private void ShootBouncy()
    {
        for(int i = 0; i < multiShot; i++)
        {
            // Calculate the angle for each bullet
            float angle;
            if(multiShot > 1)
            {
                angle = -30 + i * 60/(multiShot-1);
            }
            else
            {
                angle = 0;
            }
            
            // Shoot the bullet and adjust it's speed
            BounceOffWall bullet = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, angle, 0)).GetComponent<BounceOffWall>();
            bullet.speed *= bulletSpeed;
        }
        Invoke("ShootBouncy", shootingSpeed*3);
    }

    // Repetedly shoots multiple projectiles
    private void ShootMulti()
    {
        for(int i = 0; i < multiShot; i++)
        {
            // Calculate the angle for each bullet
            float angle;
            if(multiShot > 1)
            {
                angle = -30 + i * 60/(multiShot-1);
            }
            else
            {
                angle = 0;
            }
            
            // Shoot the bullet and adjust it's speed
            MoveForward bullet = Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, angle, 0)).GetComponent<MoveForward>();
            bullet.speed *= bulletSpeed;
        }
        Invoke("ShootMulti", shootingSpeed);
    }

    // Repetedly shoots tracking projectiles
    private void ShootTracking()
    {
        // Shoot the bullet and adjust it's speed
        MoveTowardPlayer bullet = Instantiate(projectile, transform.position + Vector3.back*3, transform.rotation).GetComponent<MoveTowardPlayer>();
        bullet.speed *= bulletSpeed;
        Invoke("ShootTracking", shootingSpeed);
    }

    // Checks for collisions with projectiles
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("playerShot"))
        {
            loseHealth(1);
            Destroy(other.gameObject);
        }
    }

    // Loses health when hit by projectile
    private void loseHealth(float amount)
    {
        currentHealth -= amount;
        healthbar.value = currentHealth;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
