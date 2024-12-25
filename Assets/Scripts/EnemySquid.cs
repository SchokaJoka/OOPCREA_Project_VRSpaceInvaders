using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquid : EnemyArmy, IDamageable
{
    public ScoreDisplay scoreDisplay;
    private bool isDestroyed = false;
    
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
        if (isDestroyed)
        {
            return;
        }
        isDestroyed = true;
        Debug.Log("SQUID: Object destroyed");
        Destroy(gameObject);
        scoreDisplay.AddPoints(30);
        GameSceneManager.Instance.CheckAllEnemiesDestroyed();
    }
}
