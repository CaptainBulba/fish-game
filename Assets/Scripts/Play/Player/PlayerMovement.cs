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

    private bool isCrashed = false;

    private AudioSource audioSource;
    public AudioClip buttonSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        gameController = controllerObject.GetComponent<GameController>();
        lastXcords = transform.position.x;
    }

    void Update()
    {
        if (!gameController.GetIsStart())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayButtonSound();
                gameController.StartGame();
            }
                
        }
        else
        {
            if (!gameController.GetIsPause() && !GetIsCrashed()) 
                Move();

            if (Input.GetKeyDown(KeyCode.P))
            {
                PlayButtonSound();
                if (!gameController.GetIsPause())
                {
                    FreezePlayer();
                    gameController.SetGamePause(true);
                }
                else 
                    gameController.SetGamePause(false);
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

    public void FreezePlayer()
    {
        rb.velocity = Vector3.zero;
    }

    public bool GetIsCrashed()
    {
        return isCrashed;
    }

    public bool SetIsCrashed(bool value)
    {
        return isCrashed = value;
    }

    private void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}
