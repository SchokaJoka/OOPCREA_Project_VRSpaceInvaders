using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    // public ScoreDisplay scoreDisplay;
    public EnemyMovement movement;
    protected bool isDestroyed = false;

    
    public void CheckComponents()
    {
        if (!movement)
        {
            Debug.LogError("EnemyOctopus.cs: EnemyMovement Script Not Found in Parent");
        }
        
        /*
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<ScoreDisplay>();
        if (!scoreDisplay)
        {
            Debug.LogError("EnemyOctopus.cs: scoreDisplay Not Found");
        }
        */
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            movement.OnWallHit();
        }
    }
}
