using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;

    public int GetScore()
    {
        return score;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
