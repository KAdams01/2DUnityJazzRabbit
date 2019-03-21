using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpaz : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    public float speed;
    public bool lastTimeRight { get; private set; }

    private Rigidbody2D rb2d;
    private bool jump;
    private Animator animator;
    private float move;
    private SoundManager sm;

    // Use this for initialization
    void Start()
    {
        sm = SoundManager.Instance;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastTimeRight = transform.localScale.x != -1;
    }

    private void Update()
    {
        jump = Input.GetButtonDown("Jump2");
        move = Input.GetAxis("Horizontal2");
        //Debug.Log(lastTimeRight);
        if (move > 0.1 && !lastTimeRight)
        {
            FlipCharacter();
            animator.SetBool("lastTimeRight", true);
            animator.SetFloat("speed", Mathf.Abs(move));
        }
        //changes to 0.1 rather than 0 for both of these for logic issues 
        else if (move < 0.1 && lastTimeRight)
        {
            FlipCharacter();
            animator.SetBool("lastTimeRight", true);
            animator.SetFloat("speed", Mathf.Abs(move));
        }

        else
        {
            animator.SetFloat("speed", Mathf.Abs(move));
        }

        Jump();
    }

    private void FlipCharacter()
    {
        lastTimeRight = !lastTimeRight;
        //transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        transform.Rotate(0f, 180f, 0f);
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);
    }

    private void Jump()
    {
        if (!jump) return;
        sm.PlayJumpingSound();
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
    }
}
