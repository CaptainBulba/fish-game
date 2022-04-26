using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedUp;
    public float speedDown;
    public float xMovement;
    private float yMovement;

    private Rigidbody2D rb;

    public GameObject controllerObject;
    private GameController gameController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = controllerObject.GetComponent<GameController>();
    }

    void Update()
    {
        if (gameController.GetGamePause())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameController.SetGamePause(false);
            }
            else
                rb.velocity = Vector3.zero;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                gameController.SetGamePause(true);
            }
                
            if (Input.GetKey(KeyCode.Space))
                yMovement = speedUp;
            else
                yMovement = -speedDown;
            Move();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(xMovement, yMovement);
    }
}
