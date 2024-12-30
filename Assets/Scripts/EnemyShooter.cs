using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : EnemyArmy
{
    public GameObject enemyProjectilePrefab;
    
    public float minShootInterval = 3.0f; // Minimum time between shots
    public float maxShootInterval = 5.0f; // Maximum time between shots
    
    private float shootTimer = 0f;
    private float shootInterval;
    
    void Start()
    {
        //Randomize the shoot interval for each enemy
        shootInterval = Random.Range(minShootInterval, maxShootInterval);
    }
    
    void Update()
    {
        // Update the timer
        shootTimer += Time.deltaTime;

        // Check if it's time to shoot and no enemy is in front
        if (shootTimer >= shootInterval)
        {
            //Raycast check before shooting
            if (!IsEnemyInFront())
            {
                FireProjectile();
                shootTimer = 0f; // Reset the timer
                //Randomize the next shoot interval
                shootInterval = Random.Range(minShootInterval, maxShootInterval);
            }
        }
    }
    
    public void FireProjectile()
    {
        Vector3 spawnPos = transform.position + transform.forward * -1.5f;
        Instantiate(enemyProjectilePrefab, spawnPos, Quaternion.identity);
        EnemyBullet bullet = enemyProjectilePrefab.GetComponent<EnemyBullet>();
        bullet.moveDirection = Vector3.back; // Set the direction to move downwards
    }
    
    private bool IsEnemyInFront()
    {
        float rayDistance = 10.0f; // Maximum distance each ray will "travel"
        float raySpacing = 0.5f; // Space between each ray (to cover a wider area)
        int numberOfRays = 3; // Number of rays to cast

        for (int i = -numberOfRays / 2; i <= numberOfRays / 2; i++)
        {
            // The Origin of each ray (offseting from the enemy' position)
            Vector3 rayOrigin = transform.position + transform.right * i * raySpacing;
            // Set the direction to move downwards
            Vector3 rayDirection = -transform.forward;

            // Draw a debug line to visualize the raycast
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red);

            // Cast a ray forward
            if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hit, rayDistance))
            {
                if (hit.collider.gameObject.CompareTag("Octopus") || hit.collider.gameObject.CompareTag("Crab") || hit.collider.gameObject.CompareTag("Squid"))
                {
                    return true; // There's an enemy in front
                }
            }
        }
        return false; // There's no enemy in front
    }
}
