using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOctopus : EnemyArmy, IDamageable
{
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        enemyPoints = 10;
    }
    
    public void OnHit()
    {
        if (isDestroyed)
        {
            return;
        }
        isDestroyed = true;
        // Debug.Log("OCTOPUS: Object destroyed");
        Destroy(gameObject);
       scoreDisplay.AddPoints(enemyPoints);
    }
}
