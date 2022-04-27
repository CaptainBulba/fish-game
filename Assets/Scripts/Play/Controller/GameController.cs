using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject startText;
    public GameObject scoreText;
    
    private bool gamePause = true;

    private Spawner spawnerScript;

    private float distance = 0f;

    void Start()
    {
        spawnerScript = GetComponent<Spawner>();
    }

    public bool GetGamePause()
    {
        return gamePause;
    }

    public bool SetGamePause(bool value)
    {
        if(value)
        {
            SetStartText(false);
            SetScoreText(true);
        } 
        else
        {
            SetStartText(false);
            SetScoreText(true);
        }
        spawnerScript.StartSpawning();
        return gamePause = value;
    }

    public void SetStartText(bool value)
    {
        startText.SetActive(value);
    }

    public void SetScoreText(bool value)
    {
        scoreText.SetActive(value);
    }

    public float GetScore()
    {
        return distance;
    }

    public void AddScore(float value)
    {
        distance += value;
        scoreText.GetComponent<Text>().text = "Distance: " + Mathf.Round(distance);
    }
}
