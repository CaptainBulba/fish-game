using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 0.5f;

    // Obstacle max & mix cords
    public float upperMinHeight = 5f;
    public float upperMaxHeight = 3f;

    public Camera cam;

    private float rightScreenEdge;
    private float extraScreenOut = 5f;

    private GameObject instanObject;

    private GameController gameController;

    void Start()
    {
        gameController = GetComponent<GameController>();
    }

    public void StartSpawning()
    {
        if(gameController.GetGamePause())
            InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        else
            CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        rightScreenEdge = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth, 0)).x + extraScreenOut;
        float upperCords = Random.Range(upperMinHeight, upperMaxHeight);

        instanObject = Instantiate(obstaclePrefab, new Vector2(rightScreenEdge, upperCords), Quaternion.identity);
        instanObject.transform.parent = gameObject.transform;
    }
}
