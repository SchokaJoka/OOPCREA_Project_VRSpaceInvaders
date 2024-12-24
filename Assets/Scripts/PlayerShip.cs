using System;
using System.Collections;   
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShip : MonoBehaviour, IDamageable
{
    public float playerSpeed = 10f;
    public float horizontalInput;
    public int maxPlayerLifes = 3;
    public int currentPlayerLifes;
    
    public ScoreDisplay scoreDisplay;
    public PlayerHealthDisplay playerHealthDisplay;
    
    public GameObject projectilePrefab;
    
    void Start()
    {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        playerHealthDisplay = FindObjectOfType<PlayerHealthDisplay>();
        
        if (!scoreDisplay)
        {
            Debug.LogError("PlayerShip.cs: scoreDisplay Not Found");
        }
        if (!playerHealthDisplay)
        {
            Debug.LogError("PlayerShip.cs: PlayerHealthDisplay Not Found");
        }
        
        currentPlayerLifes = maxPlayerLifes;
        playerHealthDisplay.UpdateHealthDisplay();
    }
    void Update()
    {
        PlayerMovement();
    }
    
    void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * playerSpeed * Time.deltaTime);
        
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

