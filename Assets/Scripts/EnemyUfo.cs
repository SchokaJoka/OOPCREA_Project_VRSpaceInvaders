using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUfo : EnemyArmy, IDamageable
{
    
    // Start is called before the first frame update
    void Start()
    {
        CheckComponents();
    }
    
    public void OnHit()
    {
        Debug.Log("UFO: Object destroyed");
        Destroy(gameObject);
        // Add Score randomizer for UFO
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            base.OnWallHit();
        }
    }
}
