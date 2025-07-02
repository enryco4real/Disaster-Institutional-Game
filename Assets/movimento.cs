using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento : MonoBehaviour
{
    [Header("Movimento")]
    public float baseSpeed = 5f;
    public float acceleration = 0.2f;
    public float maxSpeed = 10f;
    private float currentSpeed;

    [Header("Pulo")]
    public float JumpForce;
    private bool isGrounded;

    private Rigidbody2D rig;
    private Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        currentSpeed = baseSpeed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!PlayerStatus.playerDestroyed)
        {

            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

            movi();
            jump();
        }
    }

    void movi()
    {

        Vector3 movement = new Vector3(1f, 0f, 0f);
        transform.position += movement * Time.deltaTime * currentSpeed;
    }

    void jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("jump", true);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            anim.SetBool("jump", false);
        }
       
    } 
    
    
}


