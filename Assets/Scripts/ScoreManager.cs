﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    

    private void Start()
    {
        UpdateScore(score);  
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score : " + score;
    }
 
}