using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int winScore = 900;

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
        ScoreDisplay.OnScoreChanged += CheckWinCondition;
        PlayerShip.OnHealthChanged += CheckLooseCondition;
    }

    private void OnDestroy()
    {
        ScoreDisplay.OnScoreChanged -= CheckWinCondition;
        PlayerShip.OnHealthChanged -= CheckLooseCondition;
    }
    
    private void CheckWinCondition(int currentScore)
    {
        if (currentScore >= winScore)
        {
            GameSceneManager.Instance.LoadWinScene();
        }
    }
    
    private void CheckLooseCondition(int currentPlayerLifes)
    {
        if (currentPlayerLifes <= 0)
        {
            GameSceneManager.Instance.LoadGameOverScene();
        }
    }
}
