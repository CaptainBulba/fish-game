using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject startInterface;
    public GameObject playInterface;
    public GameObject pauseInterface;

    public TextMeshProUGUI distanceText;

    private bool isPause = false;
    private bool isStart = false;

    private Spawner spawnerScript;

    private float distance = 0f;

    void Start()    
    {
        spawnerScript = GetComponent<Spawner>();
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
