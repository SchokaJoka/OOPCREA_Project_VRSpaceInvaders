using System.Collections;   
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class PlayerShip : MonoBehaviour, IDamageable
{
    public float playerSpeed = 10f;
    public float horizontalInput;
    public int maxPlayerLifes = 3;
    public int currentPlayerLifes;
    
    public GameObject projectilePrefab;
    
    // Array of health objects in the 3D world (instead of UI Images)
    public GameObject[] healthObjects = new GameObject[3]; // Array with 3 slots

    // Material or color for full health and empty health
    public Material fullHealthMaterial; // Material for full health
    public Material emptyHealthMaterial; // Material for empty health
    
    void Start()
    {
        currentPlayerLifes = maxPlayerLifes;
        UpdateHealthDisplay();
    }
    void Update()
    {
        playerMovement();
        
    }
    
    void playerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * playerSpeed * Time.deltaTime);
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fireProjectile();
        }
    }
    void fireProjectile()
    {
        Vector3 spawnPos = transform.position + transform.forward * 1.5f;
        Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    public void OnHit()
    {
        Debug.Log("Player took damage");
        currentPlayerLifes--;
        UpdateHealthDisplay();
        if (currentPlayerLifes == 0)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
        
        
    }
    
    void UpdateHealthDisplay()
    {
        // Loop through the health objects and update their appearance based on current lives
        for (int i = 0; i < healthObjects.Length; i++)
        {
            if (i < currentPlayerLifes)
            {
                // Set material or enable the object for full health
                healthObjects[i].GetComponent<Renderer>().material = fullHealthMaterial;
            }
            else
            {
                // Set material or disable the object for empty health
                healthObjects[i].GetComponent<Renderer>().material = emptyHealthMaterial;
            }
        }
    }
}

