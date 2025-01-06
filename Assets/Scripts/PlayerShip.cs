using System;
using System.Collections;   
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShip : MonoBehaviour, IDamageable
{
    public float playerSpeed = 10f;
    private float rotationSpeed = 50f;
    public float horizontalInput;
    public int maxPlayerLifes = 3;
    public int currentPlayerLifes;
    private Quaternion targetRotation;
    
    public GameObject ship;
    
    public ScoreDisplay scoreDisplay;
    public PlayerHealthDisplay playerHealthDisplay;
    
    public GameObject projectilePrefab;
    
    void Start()
    {
        if (!scoreDisplay)
        {
            Debug.LogError("PlayerShip.cs: scoreDisplay Not Found");
        }
        if (!playerHealthDisplay)
        {
            Debug.LogError("PlayerShip.cs: PlayerHealthDisplay Not Found");
        }

        if (!ship)
        {
            Debug.LogError("PlayerShip.cs: Shipmodel Not Found");
        }
        
        currentPlayerLifes = maxPlayerLifes;
        playerHealthDisplay.UpdateHealthDisplay();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        playerHealthDisplay = FindObjectOfType<PlayerHealthDisplay>();
    }
    void Update()
    {
        PlayerMovement();
    }
    
    void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * playerSpeed * Time.deltaTime, 0f, 0f);
        
        // Define the target rotation
        targetRotation = Quaternion.Euler(0f, 0f, horizontalInput * -45f);

        // Smoothly rotate towards the target
        ship.transform.rotation = Quaternion.Slerp(ship.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }
    void FireProjectile()
    {
        Vector3 spawnPos = transform.position + transform.forward * 1.5f;
        Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
    }

    public void OnHit()
    {
        Debug.Log("Player took damage");
        currentPlayerLifes--;
        playerHealthDisplay.UpdateHealthDisplay();
        if (currentPlayerLifes == 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
    }



    public int GetCurrentPlayerLifes()
    {
        return currentPlayerLifes;
    }
}

