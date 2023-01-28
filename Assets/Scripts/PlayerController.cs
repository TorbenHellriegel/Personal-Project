using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Variables for player movement
    public GameObject cam;
    private float horizontalInput;
    [SerializeField] private float horizontalMovementBorder = 70;
    [SerializeField] private float verticalMovementBorderTop = 40;
    [SerializeField] private float verticalMovementBorderBottom = -40;
    private Vector3 mousePos;
    private float distToCamera;

    // Variables for shooting
    public GameObject projectile;
    public float shootingSpeed = 0.1f;

    // Variables for player health
    public Slider healthbar;
    public float maxHealth = 10;
    public float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        // Calculate distance to vamera to acurately follow the curser on the screen
        distToCamera = cam.transform.position.y - transform.position.y;

        currentHealth = maxHealth;
        healthbar.maxValue = maxHealth;
        healthbar.value = currentHealth;

        Invoke("Shoot", shootingSpeed);
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

    // Repetedly shoots projectiles
    private void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        Invoke("Shoot", shootingSpeed);
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
        healthbar.value = currentHealth;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
