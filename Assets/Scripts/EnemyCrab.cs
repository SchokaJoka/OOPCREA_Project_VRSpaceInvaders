using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrab : EnemyArmy, IDamageable
{
    // Unity
    public override void Start()
    {
        base.Start();
        enemyPoints = 20;
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
