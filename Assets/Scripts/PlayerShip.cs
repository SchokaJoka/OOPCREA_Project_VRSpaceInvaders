using System;
using System.Collections;   
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour, IDamageable
{
    // Variables
    private float playerSpeed = 10f;
    private float rotationSpeed = 50f;
    private int currentPlayerLifes;
    private float lastShotTime;
    [SerializeField] private float cooldownDuration = 0.5f;
    
   
    public float horizontalInput;
    private Quaternion targetRotation;
    
    // Components, References
    public PlayerHealthDisplay playerHealthDisplay;
    public GameObject projectilePrefab;
    public GameObject ship;
    
    // Events
    public static event Action<int> OnPlayerTookDamage;
    
    // Unity
    void Start()
    {
        // Initializing References
        CheckComponents();
        
        currentPlayerLifes = GameManager.Instance.GetPersistentPlayerLives();
        playerHealthDisplay.UpdateHealthDisplay(currentPlayerLifes);
    }
    void Update()
    {
        PlayerMovement();
    }
    
    // IDamageable Interface
    public void OnHit()
    {
        currentPlayerLifes--;
        OnPlayerTookDamage?.Invoke(currentPlayerLifes);
    }
    
    // Methods
    void PlayerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * playerSpeed * Time.deltaTime, 0f, 0f);
        
        // Define the target rotation
        targetRotation = Quaternion.Euler(0f, 0f, horizontalInput * -45f);

        // Smoothly rotate towards the target
        ship.transform.rotation = Quaternion.Slerp(ship.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShotTime + cooldownDuration)
        {
            FireProjectile();
            lastShotTime = Time.time;
        }
    }
    void FireProjectile()
    {
        Vector3 spawnPos = transform.position + transform.forward * 1.5f;
        Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
    }
    private void CheckComponents()
    {
        playerHealthDisplay = FindObjectOfType<PlayerHealthDisplay>();
        
        if (!playerHealthDisplay)
        {
            Debug.LogError("PlayerShip.cs: playerHealthDisplay not Found");
        }
        if (!ship)
        {
            Debug.LogError("PlayerShip.cs: ship not Found");
        }

        if (!projectilePrefab)
        {
            Debug.LogError("PlayerShip.cs: projectilePrefab not found!");
        }
    }
    public int GetCurrentPlayerLifes()
    {
        return currentPlayerLifes;
    }

}

