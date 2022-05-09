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

    private float maxObstacleRotation = 180f;

    void Start()
    {
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
        if (objectToSpawn) instanObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0f, maxObstacleRotation));
    }
}
