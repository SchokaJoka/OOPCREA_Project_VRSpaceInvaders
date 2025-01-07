using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyUfo : EnemyArmy, IDamageable
{
    // Unity
    public override void Start()
    {
        base.Start();
        enemyPoints = 100;
        // Add point Randomizer
    }
    
    // IDamageable Interface
    public void OnHit()
    {
        if (isDestroyed)
        {
            return;
        }
        isDestroyed = true;
        InvokeOnEnemyDied(enemyPoints);
        Destroy(gameObject);
    }
}
