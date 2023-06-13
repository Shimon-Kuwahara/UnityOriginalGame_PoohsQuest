using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float x_val;

    private float speed;
    public float inputSpeed = 20.0f;

    float jumpForce = 340f;
    public int jumpCount = 0;

    public bool OnGround;
    public bool Attack;

    private Animator animator;
    public GameObject jump1;
    public GameObject jump2;

    public AudioClip jump;
    public AudioClip jum;
    AudioSource audioSource;

    void Start()
    {
    //    Debug.Log(GetComponent<Renderer>().material.color);
        rb2d = GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        OnGround = false;

        audioSource = GetComponent<AudioSource>();

    }
    void Update()
    {
        x_val = Input.GetAxis("Horizontal");

        //Debug.Log(GetComponent<Renderer>().material.color);

        if (Attack == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && this.jumpCount < 2)
            {
                audioSource.PlayOneShot(jump);
                jumpCount++;
                if (jumpCount == 1)
                {
                    GameObject effect = Instantiate(jump2, this.gameObject.transform.position - new Vector3 (0,0.5f,0), Quaternion.identity); // エフェクトを生成
                    Destroy(effect, 1.2f);
                    this.rb2d.AddForce(Vector2.up * jumpForce);
                }

                if(jumpCount == 0)
                {
                    //GameObject effect = Instantiate(jump1, this.gameObject.transform.position - new Vector3(0, 1, 0), Quaternion.identity); // エフェクトを生成
                    //Destroy(effect, 1f);
                    this.rb2d.AddForce(Vector2.up * jumpForce);
                }
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
            GetComponent<Renderer>().material.color =UnityEngine.Color.HSVToRGB(1, 0.8f, 0.8f);
        }


        float Axis = Input.GetAxis("Horizontal");

        animator.SetFloat("valueX", Axis);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.gameObject.transform.localScale = new Vector3(-1,1, 1);
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
            if (jumpCount == 2)
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
            if (jumpCount == 2)
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            jumpCount = 0;
            OnGround = true;
            animator.SetFloat("jump", 0f);
        }
        else
        {
            jumpCount = 0;
            OnGround = true;
            animator.SetFloat("jump", 1f);
        }
    }

    void aEnd()
    {
        Attack = false;
        animator.SetFloat("attack", 0f);
        GetComponent<Renderer>().material.color = UnityEngine.Color.HSVToRGB(1,0,1);
    }
}