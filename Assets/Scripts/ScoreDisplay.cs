using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshPro scoreText;
    private int playerScore = 0;
    
    void Start()
    {
        UpdateScoreText();
    }

    public void AddPoints (int addPoints)
    {
        playerScore += addPoints;
        UpdateScoreText();
    }

    void UpdateScoreText ()
    {
        scoreText.text = "Score: " + playerScore;
    }
}
