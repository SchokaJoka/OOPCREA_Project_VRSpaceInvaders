using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int numbersOfEnemies;
    public static int currentNumbersOfEnemies;
    public int playerScore;
    public int playerHealth;

    private void Awake()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        EnemyArmy.OnEnemyDied += CheckRestartCondition;
        PlayerShip.OnHealthChanged += CheckLooseCondition;
        CheckNumbersOfEnemies();
    }

    private void OnDestroy()
    {
        EnemyArmy.OnEnemyDied -= CheckRestartCondition;
        PlayerShip.OnHealthChanged -= CheckLooseCondition;
    }
    
    private void CheckRestartCondition()
    {
        int health = playerShip.GetCurrentPlayerLifes();
        currentNumbersOfEnemies--;
        if (currentNumbersOfEnemies <= 0)
        {
            GameSceneManager.Instance.LoadMainScene();
            
        }
    }
    
    private static void CheckLooseCondition(int currentPlayerLifes)
    {
        if (currentPlayerLifes <= 0)
        {
            GameSceneManager.Instance.LoadGameOverScene();
        }
    }

    public static void CheckNumbersOfEnemies()
    {
        numbersOfEnemies = FindObjectsOfType<EnemyShooter>().Length;
        Debug.Log($"GameManager.cs: Found {numbersOfEnemies} Enemys!");
        currentNumbersOfEnemies = numbersOfEnemies;

    }
}
