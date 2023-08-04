using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public AudioClip JumpClip;
    public AudioClip DeathClip;
    private float jumpForce = 0f;
    private int life = 3;
    private int DashCount 

    private bool isGrounded = false;
    private bool isDead = false;

    private SpriteRenderer playerRenderer;
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;
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
        if(isDead)
        {
            return;
        }

        if (PlayerConroller.instance.hor == -1)
        {
            playerRigidbody.velocity = vector2(-1,)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y >0.7f)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
