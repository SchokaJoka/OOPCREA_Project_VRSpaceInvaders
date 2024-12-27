using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquid : EnemyArmy, IDamageable
{
    
    // Start is called before the first frame update
    void Start()
    {
        CheckComponents();
    }

    public void OnHit()
    {
        if (isDestroyed)
        {
            return;
        }
        isDestroyed = true;
        Debug.Log("SQUID: Object destroyed");
        Destroy(gameObject);
        // scoreDisplay.AddPoints(30);
    }
}
