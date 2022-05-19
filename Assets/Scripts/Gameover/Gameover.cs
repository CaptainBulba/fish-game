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
    public TextMeshProUGUI factText;

    public AudioClip gameoverMusic;

    private string playScene = "Play";

    private string distanceName = "distance";
    private string factName = "fact";

    void Start()
    {
        MusicController.Instance.ChangeMusic(gameoverMusic);

        float distance = PlayerPrefs.GetFloat(distanceName);
        string fact = PlayerPrefs.GetString(factName);

        if (distance < 1000f)
            distanceText.text = "Distance: " + Math.Round(distance) + " m";
        else
            distanceText.text = "Distance: " + Math.Round(distance / 1000, 2) + " km";

        factText.text = fact;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(playScene);
    }
}
