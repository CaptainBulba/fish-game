using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public GameController gameController;

    private string obstacleTag = "Obstacle";
    private string gameoverScene = "Gameover";

    private string distanceName = "distance";
    private string factName = "fact";

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == obstacleTag)
        {
            PlayerPrefs.SetFloat("distance", gameController.GetDistance());
            PlayerPrefs.SetString("fact", col.gameObject.GetComponent<ObstacleData>().GetRandomFact());
            SceneManager.LoadScene(gameoverScene);
        }
    }
}
