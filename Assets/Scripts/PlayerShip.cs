using System.Collections;   
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShip : MonoBehaviour, IDamageable
{
    public float playerSpeed = 10f;
    public float horizontalInput;
    public float verticalInput;
    
    public GameObject projectilePrefab;

    void Update()
    {
        playerMovement();
    }
    
    void playerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * playerSpeed * Time.deltaTime);
        
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * playerSpeed * Time.deltaTime);
        
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

    public void OnHit(float damage)
    {
        Debug.Log("Player took damage");
    }
}

