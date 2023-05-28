using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float x_val;

    private float speed;
    public float inputSpeed = 20.0f;

    float jumpForce = 400f;
    public int jumpCount = 0;

    public bool OnGround;
    public bool Attack;

    private Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        OnGround = false;
    }
    void Update()
    {
        x_val = Input.GetAxis("Horizontal");

        if (Attack == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && this.jumpCount < 2)
            {
                this.rb2d.AddForce(transform.up * jumpForce);
                jumpCount++;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.rb2d.AddForce(transform.up * -1f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack = true;
            animator.SetFloat("attack", 1.0f);
            Invoke("aEnd", 1.0f);
        }


        float Axis = Input.GetAxis("Horizontal");

        animator.SetFloat("valueX", Axis);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.localScale = new Vector3(2, 2, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.localScale = new Vector3(-2, 2, 1);
        }
    }
    void FixedUpdate()
    {
        if (x_val == 0)
        {
            speed = 0;
        }
        else if (x_val > 0)
        {
            if (Attack == true || jumpCount == 2)
            {
                speed = inputSpeed * 0.3f;
            }
            else
            {
                speed = inputSpeed;
            }
        }
        else if (x_val < 0)
        {
            if (Attack == true || jumpCount == 2)
            {
                speed = inputSpeed * -0.3f;
            }
            else
            {
                speed = inputSpeed * -1;
            }
        }
        // キャラクターを移動 Vextor2(x軸スピード、y軸スピード(元のまま))
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
            OnGround = true;
            animator.SetFloat("jump", 0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            OnGround = false;
            animator.SetFloat("jump", 1.0f);
        }
    }


    void aEnd()
    {
        Attack = false;
        animator.SetFloat("attack", 0f);
    }
}