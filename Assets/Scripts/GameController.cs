using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject startText;
    public GameObject scoreText;
    
    private bool gamePause = true;

    private Spawner spawnerScript;

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
}
