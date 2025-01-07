using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    // Variables
    protected int enemyPoints;
    protected bool isDestroyed = false;
    
    // Components, References
    protected static ScoreDisplay scoreDisplay;
    private EnemyRowMovement rowMovement;
    
    // Events
    public static event Action OnEnemyDied;
    
    // Unity
    public virtual void Start()
    {
        // Initializing References
        CheckComponents();
    }
    
    // Collision handling
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Border"))
        {
            OnWallHit();
        }
    }
    
    // Methods
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
    protected static void InvokeOnEnemyDied(int points)
    {
        scoreDisplay.AddPoints(points);
        OnEnemyDied?.Invoke();
    }
    private void CheckComponents()
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
}
