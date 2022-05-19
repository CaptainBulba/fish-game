using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private AudioSource audioSource;
    private PlayerMovement playerMovement;
    private GameController gameController;

    private string obstacleTag = "Obstacle";
    private string gameoverScene = "Gameover";

    private string distanceName = "distance";
    private string factName = "fact";

    public float changeSceneAfter;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        gameController = playerMovement.controllerObject.GetComponent<GameController>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == obstacleTag && !playerMovement.GetIsCrashed())
        {
            playerMovement.FreezePlayer();
            StartCoroutine(GameOver(col.gameObject));
        }
    }

    IEnumerator GameOver(GameObject obstacle)
    {

        playerMovement.SetIsCrashed(true);

        audioSource.PlayOneShot(obstacle.GetComponent<ObstacleData>().GetObstacleSound());

        yield return new WaitForSeconds(changeSceneAfter);

        PlayerPrefs.SetFloat(distanceName, gameController.GetDistance());
        PlayerPrefs.SetString(factName, obstacle.GetComponent<ObstacleData>().GetRandomFact());

        SceneManager.LoadScene(gameoverScene);
    }
}