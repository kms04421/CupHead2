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

    public float dirX;
    //목숨
    private int life = 3;
    //대시
    private int DashCount = 1;
    //이동
    private float speed = 5f;
    //생존상태
    private bool isDead = false;
    //막힘여부
    public bool isBlocked = false;
    //점프 
    private bool isGround = true;
    private float jumpForce = 10f;
    [SerializeField]private Transform pos;
    [SerializeField]private float Radius;
    [SerializeField]private LayerMask isLayer;
    [SerializeField]private int jumpCnt;
    public int jumpCount;

    private SpriteRenderer playerRenderer;
    private Rigidbody2D PR;
    private Animator animator;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        PR = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerRenderer = GetComponent<SpriteRenderer>();
        jumpCnt = jumpCount;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        isGround = Physics2D.OverlapCircle(pos.position, Radius, isLayer);

        if (isGround == true && Input.GetKeyDown(KeyCode.Z) && jumpCnt > 0)
        {
            Debug.Log("들어오니?");
            animator.SetTrigger("jump");
            PR.velocity = Vector3.zero;
            PR.velocity = Vector2.up * jumpForce;
        }
        if (isGround == false && Input.GetKeyDown(KeyCode.Z) && jumpCnt > 0)
        {
            PR.velocity = Vector2.up * jumpForce;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            jumpCnt--;
        }
        if (isGround)
        {
            jumpCnt = jumpCount;
        }


    }

    private void FixedUpdate()
    {
        dirX = Input.GetAxis("Horizontal");
        PR.velocity = new Vector2(dirX * speed, PR.velocity.y);
        if (dirX > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            animator.SetBool("run", true);
        }
        else if (dirX < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }


       
        /*  Debug.LogFormat("{0}", isGround);
          if (isGround && Input.GetKey(KeyCode.Z))
          {


              //velo = new Vector2(PR.velocity.x, PR.velocity.y);
              if (isGround == true &&  PR.velocity.y < MaxjumpForce)
              {
                  //PR.velocity = velo;
                  PR.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
              }

          }
          if (isGround == false)
          {
              animator.SetBool("isGround", false);
          }
          if (isGround == true)
          {
              animator.SetBool("isGround", true);
          }*/


    }

    public void Die()
    {
        animator.SetTrigger("Die");
        playerAudio.clip = DeathClip;
        playerAudio.Play();
        PR.velocity = Vector2.zero;
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
        if (collision.contacts[0].normal.y < 0.5f)
        {
            isBlocked = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        isBlocked = false;

    }


}
