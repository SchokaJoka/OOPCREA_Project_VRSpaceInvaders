using UnityEngine;
using UnityEngine.Serialization;

public class EnemyShooter : MonoBehaviour
{
    // Variables
    private float minShootInterval = 6f;
    private float maxShootInterval = 20f;
    private float shootTimer = 0f;
    private float shootInterval;
    
    // Components, References
    [SerializeField]
    private GameObject bulletPrefab;
    
    // Unity
    void Start()
    {
        shootInterval = Random.Range(minShootInterval, maxShootInterval);
    }
    
    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            //Raycast check before shooting
            if (!IsEnemyInFront())
            {
                FireProjectile();
                shootTimer = 0f;
                
                //Randomize the next shoot interval
                shootInterval = Random.Range(minShootInterval, maxShootInterval);
            }
        }
    }
    
    // Methods
    private void FireProjectile()
    {
        Vector3 spawnPos = transform.position + transform.forward * -1.5f;
        GameObject bulletInstance = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
        Bullet bullet = bulletInstance.GetComponent<Bullet>();
        bullet.SetMoveDirection(Vector3.back);
        bullet.SetIsEnemyBullet(true);
        bullet.SetMoveSpeed(10f);
    }
    private bool IsEnemyInFront()
    {
        float rayDistance = 10.0f; // Maximum distance each ray will "travel"
        float raySpacing = 0.5f; // Space between each ray (to cover a wider area)
        int numberOfRays = 3; // Number of rays to cast

        for (int i = -numberOfRays / 2; i <= numberOfRays / 2; i++)
        {
            // The Origin of each ray (offseting from the enemy' position)
            Vector3 rayOrigin = transform.position + transform.right * (i * raySpacing);
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
