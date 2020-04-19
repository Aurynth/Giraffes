using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    Vector2 Movement;

    void Start()
    {
        moveSpeed = 10f;
        waitCounter = waitTime;
        walkCounter = walkTime;
        walkTime = 5;
        waitTime = 2;
        Movement.x = Random.Range(-1, 1);
        Movement.y = Random.Range(-1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * moveSpeed * Time.fixedDeltaTime);
        if(rb.position.x <= 150 || rb.position.x >= 580)
        {
            Movement.x *= (-1);
        }
        if(rb.position.y <= 30 || rb.position.y >= 350)
        {
            Movement.y *= (-1);
        }
    }
}
