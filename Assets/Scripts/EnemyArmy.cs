using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    // public ScoreDisplay scoreDisplay;
    protected bool isDestroyed = false;
    public EnemyMovementTop enemyMovementTop;

    void Start()
    {
        enemyMovementTop = GetComponent<EnemyMovementTop>();
        if (!enemyMovementTop)
        {
            Debug.LogWarning("EnemyArmy.cs: enemyMovementTop not found!");
        }

    }

    protected void OnWallHit()
    {
        enemyMovementTop.MoveDown();
    }
    
    public void CheckComponents()
    {
        /*
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<ScoreDisplay>();
        if (!scoreDisplay)
        {
            Debug.LogError("EnemyOctopus.cs: scoreDisplay Not Found");
        }
        */
    }
    

}
