using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Variables
    public float lifeTime = 5.0f;
    private float moveSpeed = 30f;
    private bool isEnemyBullet = false;
    private Vector3 moveDirection = Vector3.forward; // Default direction is upwards
    
    // Unity
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.Translate(moveDirection * (Time.deltaTime * moveSpeed));
    }
    
    // Collision Handling
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            if (isEnemyBullet)
            {
                // Ignore collision with other enemies
                if (other.gameObject.CompareTag("Octopus") || other.gameObject.CompareTag("Crab") || other.gameObject.CompareTag("Squid"))
                {
                    return;
                }
            }
            damageable.OnHit();
            Destroy(gameObject);
        }
    }
    
    // Methods
    public void SetIsEnemyBullet(bool newIsEnemyBullet)
    {
        isEnemyBullet = newIsEnemyBullet;
    }
    public void SetMoveDirection(Vector3 newMoveDirection)
    {
        moveDirection = newMoveDirection;
    }
    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed; 
    }
}