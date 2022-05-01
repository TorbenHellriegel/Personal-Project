using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 3;
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
