using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
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
    //이동
    private float speed = 5f;
    //생존상태
    private bool isDead = false;
    //막힘여부
    public bool isBlocked = false;
    //점프 
    private bool isGround = true;
    //엎드림여부
    public bool isDown = false;
    //위보는여부
    public bool isUp = false;
    //에임여부
    public bool isAim = false;
    //대시여부
    public bool isDash = false;
    public bool isDashing = false;


    // Vector3 변수로 시작 위치와 종료 위치를 선언합니다.
    private Vector3 startPos, endPos;

    // 땅에 닿기까지의 시간을 계산하는 변수
    protected float timer;
    protected float timeToFloor;

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
        #region 점프동작
        
        #endregion
        #region 위를올려다보는동작
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isUp = true;
            animator.SetBool("lookup", true);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isUp = false;
            animator.SetBool("lookup", false);
        }
        #endregion
        #region 아래를바라보는동작
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("lookdown", true);
            isDown = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //Debug.LogFormat("들어오니?");
            animator.SetBool("lookdown", false);
            isDown = false;
        }
        #endregion
        #region 공격하는 동작
        if (Input.GetKey(KeyCode.X))
        {
            animator.SetBool("attack",true);
        }
        if(Input.GetKeyUp(KeyCode.X))
        {
            animator.SetBool("attack", false);
        }
        #endregion
        #region 대각선 위 동작
        if (isUp == true && Mathf.Abs(dirX) >0)
        {
            animator.SetBool("diagonal", true);
        }
        else
        {
            animator.SetBool("diagonal", false);
        }
        #endregion
        #region 대각선아래 동작
        //대각선 아래 동작
        if (isDown == true && Mathf.Abs(dirX) > 0)
        {
            animator.SetBool("downdiagonal", true);
        }
        else
        {
            animator.SetBool("downdiagonal", false);
        }
        #endregion
        #region 조준동작
        if (Input.GetKey(KeyCode.C))
        {
            isAim = true;
            animator.SetBool("aim", true);
        }
        else
        {
            isAim = false;
            animator.SetBool("aim", false);
        }
        #endregion
        #region 대쉬동작

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("dash",true);
            isDash = true;
        }
        #endregion
    }

    private void FixedUpdate()
    {
        if (isDash == true&&isDashing == false)
        {
            StartCoroutine(Dash(transform.position));
        }
        #region 이동구현
        dirX = Input.GetAxis("Horizontal");
        
        
        if (!(isDown == true || isUp == true || isAim == true || isDash == true || isGround == false))
        {
            PR.velocity = new Vector2(dirX * speed, PR.velocity.y);
            if (dirX > 0)
            {
                animator.SetBool("run", true);
            }
            else if (dirX < 0)
            {
                animator.SetBool("run", true);
            }
            else
            {
                animator.SetBool("run", false);
            }

        }
        #endregion
        #region 좌우반전구현 
        if (dirX >0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(dirX<0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        #endregion
    }
    #region 죽음구현
    public void Die()
    {
        playerAudio.clip = DeathClip;
        playerAudio.Play();
        PR.velocity = Vector2.zero;
        isDead = true;
    }
    #endregion
    #region 피격구현
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Boss" || collision.tag == "BossATK")&& isDead ==false)
        {
            life -= 1;
            animator.SetTrigger("hit");
            if (life == 0)
            {
                animator.SetBool("Die",true);
                Die();
            }            
        }

    }
    #endregion
    #region 막힘체크
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
    #endregion
    #region 대쉬
    IEnumerator Dash(Vector2 current)
    {
        float dashDirection = transform.eulerAngles.y == 0 ? 1 : -1;
        Vector2 dest = new Vector2(current.x + (dashDirection * 3.5f), current.y);
        isDashing = true;
        float timeElapsed = 0.0f;
        while (timeElapsed < 0.3f)
        {
            // 시간 경과에 따라 스케일 값 보간
            timeElapsed += Time.deltaTime;

            // Lerp 값을 0 ~ 1 사이로 변환
            float time = Mathf.Clamp01(timeElapsed / 0.2f);

            transform.position = Vector2.Lerp(current, dest, time);
            yield return null;
        }
        isDash = false;
        isDashing = false;
        animator.SetBool("dash", false);
    }
    #endregion
}
