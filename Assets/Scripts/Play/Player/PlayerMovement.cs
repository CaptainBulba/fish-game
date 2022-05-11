using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float maxFishCord;

    public float speedUp;
    public float speedDown;

    public float xMovement;
    private float yMovement;

    private float lastXcords;

    private Rigidbody2D rb;

    public GameObject controllerObject;

    private GameController gameController;

    private Animator anim;
    private string swimAnim = "Fish";

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
               // PlayAnimation(swimAnim);
            }
        }
        else
        {
            if (!gameController.GetIsPause())
            {

                Move();
                if (gameObject.transform.position.y >= maxFishCord) rb.velocity = new Vector2(rb.velocity.x, -speedDown);
            }

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
        else yMovement = -speedDown;

        rb.velocity = new Vector2(xMovement, yMovement);
        UpdateDistance();
    }

    private void UpdateDistance()
    {
        gameController.AddDistance(transform.position.x - lastXcords);
        lastXcords = transform.position.x;
    }

    public void PlayAnimation(string animName)
    {
        anim.Play(animName);
    }
}
