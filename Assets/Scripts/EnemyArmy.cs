using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour, IDamageable
{
    private float health = 100f;
    
    public void OnHit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Object destroyed");
        }
        Debug.Log("OnHit succesfull");
    }
    
}