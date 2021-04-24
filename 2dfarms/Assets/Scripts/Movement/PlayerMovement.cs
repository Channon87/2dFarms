using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 motionVector;
    public Vector2 lastMotionVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
       
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 6f;
        else
            moveSpeed = 3f;
        //input
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"),
           Input.GetAxisRaw("Vertical"));
      

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", motionVector.sqrMagnitude);
        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(
                horizontal,
                vertical
                ).normalized;
        }
    }


    void FixedUpdate()
    {
        Move();


    }
    private void Move()
    {
        rb.velocity = motionVector * moveSpeed;
    }
}
