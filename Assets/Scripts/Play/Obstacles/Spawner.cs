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

    void Start()
    {
        gameController = GetComponent<GameController>();
    }

    public void ObstacleSpawner()
    {
        if(!gameController.GetIsPause())
            InvokeRepeating(nameof(InitiateSpawning), spawnRate, spawnRate);
        else
            CancelInvoke(nameof(InitiateSpawning));
    }
    private void InitiateSpawning()
    {
        if(objectToSpawn) 
            obstaclePrefab = upperObstacles[Random.Range(0, upperObstacles.Length)];
        else if(!objectToSpawn)
            obstaclePrefab = lowerObstacles[Random.Range(0, lowerObstacles.Length)];

        ObstacleData obstacleData = obstaclePrefab.GetComponent<ObstacleData>();
        float obstacleCords = Random.Range(obstacleData.GetMinimumCord(), obstacleData.GetMaximumCord());

        Spawn(obstaclePrefab, obstacleCords);
        objectToSpawn = !objectToSpawn;
    }

    private void Spawn(GameObject obstaclePrefab, float obstacleCords)
    {
        rightScreenEdge = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, 0)).x + extraScreenOut;
        GameObject instanObject = Instantiate(obstaclePrefab, new Vector2(rightScreenEdge, obstacleCords), Quaternion.identity);
        instanObject.transform.parent = gameObject.transform;
    }
}
