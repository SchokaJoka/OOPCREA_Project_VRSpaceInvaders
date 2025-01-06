using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float lifeTime = 5.0f;
    
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate(0.0f, 0.0f, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Bullet.cs Collision with " + other.gameObject.name);
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            // Debug.Log("Bullet.cs Found IDamageable in " + other.gameObject.name);
            Destroy(gameObject);
            damageable.OnHit();
        }
    }
    
}
