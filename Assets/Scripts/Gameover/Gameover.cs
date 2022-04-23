using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    public Text scoreText;

    private string playScene = "Play";

    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("score");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(playScene);
    }
}
