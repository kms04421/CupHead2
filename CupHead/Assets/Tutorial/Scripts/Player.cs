using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance;
    public AudioClip JumpClip;
    public AudioClip DeathClip;
    private float jumpForce = 5f;
    private int life = 3;
    private int DashCount = 1;
    private float speed = 5f;
    private bool isDead = false;
    private bool isGround = false;
    private Vector2 moveDirection;
    private SpriteRenderer playerRenderer;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;
    private int previousDirection = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
       

    }

    private void FixedUpdate()
    {
        bool hasControl = (moveDirection != Vector2.zero);
        if (hasControl)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
        }

        if (moveDirection.x >= 0)
        {
            animator.SetBool("run", true);
            playerRenderer.flipX = false;

        }
        else if (moveDirection.x <= 0)
        {
            animator.SetBool("run", true);
            playerRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("run", false);
        }
    }


   
    public void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = DeathClip;
        playerAudio.Play();
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster" && isDead ==false)
        {
            life -= 1;
            if (life == 0)
            {
                Die();
            }            
        }
    }
    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        moveDirection = new Vector2(input.x,input.y);
    }
}
