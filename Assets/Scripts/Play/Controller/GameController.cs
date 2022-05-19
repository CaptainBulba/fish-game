using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip playMusic;

    public GameObject startInterface;
    public GameObject playInterface;
    public GameObject pauseInterface;

    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI fishStartText;
    public GameObject pauseFactText;

    private bool isPause = false;
    private bool isStart = false;

    private Spawner spawnerScript;

    private float distance = 0f;

    void Start()    
    {
        spawnerScript = GetComponent<Spawner>();

        MusicController.Instance.ChangeMusic(playMusic);
    }

    public bool GetIsPause()
    {
        return isPause;
    }

    public bool GetIsStart()
    {
        return isStart;
    }

    public void SetGamePause(bool value)
    {
        if(value)
        {
            SetPauseInterface(true);
            pauseFactText.GetComponent<TextMeshProUGUI>().text = pauseFactText.GetComponent<PauseFact>().pauseFactText();
            isPause = true;
        } 
        else
        {
            SetPauseInterface(false);
            isPause = false;
        }
    }

    public void SetStartInterface(bool value)
    {
        startInterface.SetActive(value);
    }

    public void SetPauseInterface(bool value)
    {
        pauseInterface.SetActive(value);
    }

    public void SetPlayInterface(bool value)
    {
        playInterface.SetActive(value);
    }

    public void StartGame()
    {
        isStart = true;
        SetStartInterface(false);
        SetPlayInterface(true);
     //   spawnerScript.ObstacleSpawner();
    }

    public float GetDistance()
    {
        return distance;
    }

    public void AddDistance(float value)
    {
        distance += value;

        if(distance < 1000f)
            distanceText.text = "Distance: " + Math.Round(distance) + " m";
        else
            distanceText.text = "Distance: " + Math.Round(distance / 1000, 2) + " km";
    }
}
