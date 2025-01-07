using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUfo : EnemyArmy, IDamageable
{
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        enemyPoints = 100;
    }
    
    public void OnHit()
    {
        Debug.Log("UFO: Object destroyed");
        Destroy(gameObject);
        // Add Score randomizer for UFO
    }
}
