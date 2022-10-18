using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBall : MonoBehaviour
{
    public Rigidbody ballRb;
    public float moveSpeed;
    public float jumpSpeed;
    private bool isOnGround = true;
    private bool canDoubleJump = false;
    private float zInput;
    private float xInput;

    void Awake()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInputs();
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) //Press Space to jump.
        {
            ballRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            isOnGround = false;
            canDoubleJump = true;
        }       
            else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && canDoubleJump) //If not on the ground, double jump is enabled.
                 {
                     ballRb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                     canDoubleJump = false;
                 }
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //touching "Ground" - Now ball can jump again.
        {
            isOnGround = true;
            canDoubleJump = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void moveInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        ballRb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }

}

