using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    // Variables
    private int playerScore = 0;
    
    // Components, References
    public TextMeshPro scoreText;
    
    // Unity
    void Start()
    {
        // Initializing References, Components
        CheckComponents();
        
        playerScore = GameManager.Instance.GetPersistentScore();
        UpdateScoreText();
    }
    
    // Methods
    public void AddPoints (int addPoints)
    {
        playerScore += addPoints;
        UpdateScoreText();
    }
    private void UpdateScoreText ()
    {
        scoreText.text = "Score: " + playerScore;
    }
    private void CheckComponents()
    {
        if (!scoreText)
        {
            Debug.LogError("ScoreDisplay.cs: scoreText not found!");
        }
    }
    public int GetCurrentScore()
    {
        return playerScore;
    }
}
