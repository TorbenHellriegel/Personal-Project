using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Checks for collisions with projectiles
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemyShot"))
        {
            loseHealth(1);
            Destroy(other.gameObject);
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
