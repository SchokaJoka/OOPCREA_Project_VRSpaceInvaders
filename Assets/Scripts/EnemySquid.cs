using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquid : EnemyArmy, IDamageable
{
    // Unity
    public override void Start()
    {
        base.Start();
        enemyPoints = 30;
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
