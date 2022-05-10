using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float maxFishCord;
    public float minFishCord;

    public float speedUp;
    public float speedDown;
    
    public float xMovement;
    private float yMovement;
    
    private float lastXcords;

    private Rigidbody2D rb;

    public GameObject controllerObject;

    private GameController gameController;

    private Animator anim;
    private string animName = "Fish";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameController = controllerObject.GetComponent<GameController>();
        lastXcords = transform.position.x;
    }

    void Update()
    {
        if (!gameController.GetIsStart())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameController.StartGame();
                anim.Play(animName);
            }
        }
        else
        {
            if (!gameController.GetIsPause()) Move();

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
       // if (gameObject.transform.position.y >= 1f) { rb.velocity = new Vector2(rb.velocity.x, -0.1f); }
        UpdateDistance();
    }

    private void UpdateDistance()
    {
        gameController.AddDistance(transform.position.x - lastXcords);
        lastXcords = transform.position.x;
    }
}
