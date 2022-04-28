using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speedUp;
    public float speedDown;
    
    public float xMovement;
    private float yMovement;
    
    private float lastXcords;

    private Rigidbody2D rb;

    public GameObject controllerObject;

    private GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = controllerObject.GetComponent<GameController>();
        lastXcords = transform.position.x;
    }

    void Update()
    {
        if (!gameController.GetIsStart())
        {
            if (Input.GetKeyDown(KeyCode.Space)) gameController.StartGame();
        }
        else
        {
            if (!gameController.GetIsPause()) Move();

            if (Input.GetKeyDown(KeyCode.R) && gameController.GetIsPause()) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            if (Input.GetKeyDown(KeyCode.P))
            {
                if (!gameController.GetIsPause())
                {
                    rb.velocity = Vector3.zero;
                    gameController.SetGamePause(true);
                }
                else gameController.SetGamePause(false);
            }
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.Space)) yMovement = speedUp;
        else  yMovement = -speedDown;

        rb.velocity = new Vector2(xMovement, yMovement);
        UpdateDistance();
    }

    private void UpdateDistance()
    {
        gameController.AddDistance(transform.position.x - lastXcords);
        lastXcords = transform.position.x;
    }
}
