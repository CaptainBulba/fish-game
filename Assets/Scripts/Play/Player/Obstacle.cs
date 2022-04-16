using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public Score score;

    private string obstacleTag = "Obstacle";
    private string gameoverScene = "Gameover";

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == obstacleTag)
        {
            PlayerPrefs.SetInt("score", score.GetScore());
            SceneManager.LoadScene(gameoverScene);
        }
    }
}
