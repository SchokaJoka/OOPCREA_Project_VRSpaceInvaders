using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy_J : EnemyArmy
{
    public GameObject enemyProjectilePrefab;
    
    public float shootInterval = 0.5f; // Time between shots
    
    private float shootTimer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
              
    }

    // Update is called once per frame
    void Update()
    {
        // Update the timer
        shootTimer += Time.deltaTime;

        // Check if it's time to shoot
        if (shootTimer >= shootInterval)
        {
            FireProjectile();
            shootTimer = 0f; // Reset the timer
        }
    }
    
    public void FireProjectile()
    {
        Vector3 spawnPos = transform.position + transform.forward * -1.5f;
        Instantiate(enemyProjectilePrefab, spawnPos, Quaternion.identity);
        //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        TESTBulletJ bullet = enemyProjectilePrefab.GetComponent<TESTBulletJ>();
        bullet.moveDirection = Vector3.back; // Set the direction to move downwards
    }
}
