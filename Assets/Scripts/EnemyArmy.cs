using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    protected bool isDestroyed = false;
    protected int enemyPoints;
    private EnemyRowMovement rowMovement;
    protected static ScoreDisplay scoreDisplay;
    public static event Action OnEnemyDied;
    
    public virtual void Start()
    {
        rowMovement = GetComponentInParent<EnemyRowMovement>();
        scoreDisplay = FindObjectOfType<ScoreDisplay>();

        if (!rowMovement)
        {
            Debug.LogWarning("EnemyArmy.cs: rowMovement not found!");
        }
        if (!scoreDisplay)
        {
            Debug.LogWarning("EnemyArmy.cs: scoreDisplay not found!");
        }
    }

    private void OnWallHit()
    {
        if (rowMovement != null)
        {
            rowMovement.MoveDown();
        }
        else
        {
            Debug.LogError("EnemyArmy.cs: Tried to move down but rowMovement is null!");
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            OnWallHit();
        }
    }
    
    protected void InvokeOnEnemyDied(int points)
    {
        scoreDisplay.AddPoints(points);
        OnEnemyDied?.Invoke();
    }

}
