using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour, IDamageable
{
    //private float health = 100f;
    
    public void OnHit()
    {
        Destroy(gameObject);
        Debug.Log("Object destroyed");
    }
    
}
