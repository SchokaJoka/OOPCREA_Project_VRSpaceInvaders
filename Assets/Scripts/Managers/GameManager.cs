using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    // Variables
    private static int numbersOfEnemies;
    private static int currentNumbersOfEnemies;

    // Unity
    private void Awake()
    {
        CheckForDuplicates();
    }
    private void Start()
    {
        EnemyArmy.OnEnemyDied += CheckRestartCondition;
        PlayerShip.OnPlayerTookDamage += CheckLooseCondition;
        CheckNumbersOfEnemies();
    }
    private void OnDestroy()
    {
        EnemyArmy.OnEnemyDied -= CheckRestartCondition;
        PlayerShip.OnPlayerTookDamage -= CheckLooseCondition;
    }
    
    // Methods
    private static void CheckRestartCondition()
    {
        currentNumbersOfEnemies--;
        if (0 >= currentNumbersOfEnemies)
        {
            GameSceneManager.Instance.LoadMainScene();
            
            // Store Player Lifes ?
            // Store Player Score ?
        }
        
        
    }
    private static void CheckLooseCondition(int currentPlayerLifes)
    {
        if (currentPlayerLifes <= 0)
        {
            //GameSceneManager.Instance.LoadGameOverScene();
            GameSceneManager.Instance.LoadGameOverNewScene();
        }
    }
    public static void CheckNumbersOfEnemies()
    {
        numbersOfEnemies = FindObjectsOfType<EnemyShooter>().Length;
        Debug.Log($"GameManager.cs: Found {numbersOfEnemies} Enemys!");
        currentNumbersOfEnemies = numbersOfEnemies;

    }
    private void CheckForDuplicates()
    {
        if (Instance && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }
}
