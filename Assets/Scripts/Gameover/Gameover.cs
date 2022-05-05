using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    int skipFrames = 10;
    int currentFrame = 0;

    private string playScene = "Play";

    void Start()
    {
        float distance = PlayerPrefs.GetFloat("distance");

        if (distance < 1000f)
            distanceText.text = "Distance: " + Math.Round(distance) + " m";
        else
            distanceText.text = "Distance: " + Math.Round(distance / 1000, 2) + " km";
    }

    void Update()
    {
        if(currentFrame <= skipFrames)
        {
            currentFrame++;
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(playScene);
    }
}
