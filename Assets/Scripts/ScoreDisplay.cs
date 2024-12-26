using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public static event Action<int> OnScoreChanged;
    
    public TextMeshProUGUI scoreText;
    private int playerScore = 0;
    
    void Start()
    {
        UpdateScoreText();
    }
    
    public void AddPoints (int points)
    {
        playerScore += points;
        UpdateScoreText();
        OnScoreChanged?.Invoke(playerScore);
    }

    void UpdateScoreText ()
    {
        scoreText.text = "Score: " + playerScore;
    }
}
