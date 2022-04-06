﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player_Controller : MonoBehaviour
{
    public float speed;

    public float jumpForce;
    private float moveInput;
    
    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;
    bool jump = false;

    public int coinValue = 1;


    // Start is called before the first frame update
    void Start()
    {
      extraJumps = extraJumpsValue;
      rb = GetComponent<Rigidbody2D>();
   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
      moveInput = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);     
      if(facingRight == false && moveInput > 0)
      {
          Flip();
      }
      else if (facingRight == true && moveInput < 0)
      {
          Flip();
      }
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true) 

        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void OnLanding()
    {
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
            ScoreManager.instance.ChangeScore(coinValue);
        }

        if (other.gameObject.CompareTag("End Level (Door)"))
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
