using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public float shootingSpeed = 0.1f;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Shoot", shootingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Repetedly shoots projectiles
    private void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        Invoke("Shoot", shootingSpeed);
    }
}
