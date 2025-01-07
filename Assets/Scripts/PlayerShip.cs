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
    private Quaternion targetRotation;
    
    private int maxPlayerLifes = 3;
    private int currentPlayerLifes;
   
    public GameObject ship;
    
    public PlayerHealthDisplay playerHealthDisplay;
    
    public GameObject projectilePrefab;
    
    public static event Action<int> OnHealthChanged;
    
    void Start()
    {
        currentPlayerLifes = maxPlayerLifes;
        playerHealthDisplay = FindObjectOfType<PlayerHealthDisplay>();
        playerHealthDisplay.UpdateHealthDisplay(currentPlayerLifes);
     
        if (!playerHealthDisplay)
        {
            Debug.LogError("PlayerShip.cs: PlayerHealthDisplay Not Found");
        }
        if (!ship)
        {
            Debug.LogError("PlayerShip.cs: Shipmodel Not Found");
        }
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
        currentPlayerLifes--;
        OnHealthChanged?.Invoke(currentPlayerLifes);
        playerHealthDisplay.UpdateHealthDisplay(currentPlayerLifes);
        
        if (currentPlayerLifes <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public int GetCurrentPlayerLifes()
    {
        return currentPlayerLifes;
    }

    public int GetMaxPlayerLifes()
    {
        return maxPlayerLifes;
    }
}

