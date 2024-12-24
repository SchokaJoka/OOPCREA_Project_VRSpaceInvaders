using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
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
    }

    void UpdateScoreText ()
    {
        scoreText.text = "Score: " + playerScore;
    }
}
