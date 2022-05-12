using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] upperObstacles;
    public GameObject[] lowerObstacles;

    public float spawnRate = 0.5f;

    public Camera cam;

    private float rightScreenEdge;
    private float extraScreenOut = 5f;

    private GameController gameController;
    private GameObject obstaclePrefab;

    private bool objectToSpawn = true;

    float[] upperRotation = new float[2] { 0f, 180f };
    float[] lowerRotation = new float[2] { -25f, 25f };

    private DeleteObstacle deleteObstacle;

    void Start()
    {
        deleteObstacle = GetComponent<DeleteObstacle>();
        gameController = GetComponent<GameController>();
        InvokeRepeating(nameof(InitiateSpawning), spawnRate, spawnRate);
    }

    private void InitiateSpawning()
    {
        if(!gameController.GetIsPause() && gameController.GetIsStart())
        {
            if (objectToSpawn)
                obstaclePrefab = upperObstacles[Random.Range(0, upperObstacles.Length)];
            else if (!objectToSpawn)
                obstaclePrefab = lowerObstacles[Random.Range(0, lowerObstacles.Length)];

            ObstacleData obstacleData = obstaclePrefab.GetComponent<ObstacleData>();
            float obstacleCords = Random.Range(obstacleData.GetMinimumCord(), obstacleData.GetMaximumCord());

            Spawn(obstaclePrefab, obstacleCords);
            objectToSpawn = !objectToSpawn;
        }
    }

    private void Spawn(GameObject obstaclePrefab, float obstacleCords)
    {
        rightScreenEdge = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, 0)).x + extraScreenOut;

        GameObject instanObject = Instantiate(obstaclePrefab, new Vector2(rightScreenEdge, obstacleCords), Quaternion.identity);
        instanObject.transform.parent = gameObject.transform;


        float minRotation, maxRotation, yRotation;

        if (objectToSpawn)
        {
            minRotation = upperRotation[0];
            maxRotation = upperRotation[1];
            yRotation = 0f;
        }
        else
        {
            minRotation = lowerRotation[0];
            maxRotation = lowerRotation[1];
            yRotation = 180f;
        }
            
        instanObject.transform.rotation = Quaternion.Euler(0.0f, yRotation, Random.Range(minRotation, maxRotation));

        StartCoroutine(deleteObstacle.SelfDestruct(instanObject));
    }
}
