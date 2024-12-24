using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUfo : EnemyArmy, IDamageable
{
    public ScoreDisplay scoreDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        if (!scoreDisplay)
        {
            Debug.LogError("PlayerShip.cs: scoreDisplay Not Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit()
    {
        Debug.Log("UFO: Object destroyed");
        Destroy(gameObject);
        // Add Score randomizer for UFO
    }
}
