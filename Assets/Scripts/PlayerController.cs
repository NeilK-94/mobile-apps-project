﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;    //  set in unity

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private bool grounded;

    private bool doubleJumped;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
	
	// Update is called once per frame
	void Update () {

        if (grounded)
        {
            doubleJumped = false;
        }

        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown (KeyCode.Space) && grounded)   //  if space is pressed
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)   //  if not double jumped and not grounded
        {
            Jump();
            doubleJumped = true;
        }

        
        if (Input.GetKey(KeyCode.D))   //  if D is pressed
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            
        }

        if (Input.GetKey(KeyCode.A))   //  if A is pressed
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);  //  - move speed as a is backwards
            
        }

        //GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, rigidbody2D.velocity.y);

        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));   //  mathf.abs returns negative value as positive

        if(GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void Jump()  //  jump method
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }


}
