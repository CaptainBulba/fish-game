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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            yMovement = speedUp;
        else
            yMovement = -speedDown;
     
 
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(xMovement, yMovement);
    }
}
