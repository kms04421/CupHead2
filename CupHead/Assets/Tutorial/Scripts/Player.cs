using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

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
    //공격여부
    public bool isAttack = false;
    //레이캐스트
    public RaycastHit2D hit;
    public float MaxDistance = 0.6f;
    //레이캐스트 바닥
    public GameObject foot;
    public RaycastHit2D hitFoot; //바닥


    // Vector3 변수로 시작 위치와 종료 위치를 선언합니다.
    private Vector3 startPos, endPos;

    // 땅에 닿기까지의 시간을 계산하는 변수
    protected float timer;
    protected float timeToFloor;

    //점프
    private float jumpForce = 2f;
    public int jumpCount;
    public Vector3[] waypoints;
    public PathType pathType;
    public PathMode pathMode;
    public Color gizmoColor;

    //
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
        instance = this;
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        #region 점프동작
        if (Input.GetKeyDown(KeyCode.Z))
        {
            /*waypoints = new Vector3[3];
            waypoints[0] = transform.position;
            waypoints[1] = new Vector3(transform.position.x+2 ,transform.position.y +3,0);
            waypoints[2] = new Vector3(transform.position.x+4, transform.position.y,0);
            pathType = PathType.CatmullRom;
            pathMode = PathMode.TopDown2D;
            PR.transform.DOLocalPath(waypoints, 1,pathType,pathMode);*/
        }
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
            isAttack = true;
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
        
        
        if ((!(isDown == true || isUp == true || isAim == true || isDash == true || isGround == false)&& !isAttack)
            || (isDown == false && isAim == false &&isDash ==false && isAttack) || (isDown ==true &&isAim ==false && isDash ==false && isAttack))
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

        #region 레이캐스트
        int layerMask = 1 << LayerMask.NameToLayer("Floor");
        Debug.DrawRay(transform.position, transform.right * MaxDistance, Color.blue, 4);
        hit = Physics2D.Raycast(transform.position, transform.right, MaxDistance,layerMask);
        

        Debug.DrawRay(foot.transform.position, foot.transform.right * MaxDistance, Color.blue, 4);
        hitFoot = Physics2D.Raycast(foot.transform.position, foot.transform.right, MaxDistance,layerMask);

        /*if(hit.collider != null)
        {
            Debug.LogFormat("머리쏘기{0}", hit.collider.name);
        }
        if(hitFoot.collider != null)
        {
            Debug.LogFormat("다리쏘기{0}", hitFoot.collider.name);
        }*/
        #endregion

        #region 좌우반전구현 
        if (isDash == false)
        {
            if (dirX > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (dirX < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
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
        while (timeElapsed < 1f)
        {
            // 시간 경과에 따라 스케일 값 보간
            timeElapsed += Time.deltaTime*3;

            // Lerp 값을 0 ~ 1 사이로 변환
            float time = Mathf.Clamp01(timeElapsed / 1f);

            if ((hit.collider !=null|| hitFoot.collider !=null))
            { // 레이와 발에있는 레이가 둘중하나라도 무언가에 맞았을때
                if ((hit.collider != null && hitFoot.collider==null) && hit.collider.tag == "Floor")
                {   //만약 레이만 맞고 맞은게 Floor일때
                    transform.position = Vector2.Lerp(current, new Vector2(hit.point.x, PR.velocity.y), time);
                }
                else if ((hit.collider == null && hitFoot.collider != null) && hit.collider.tag == "Floor")
                {   //만약 발에있는 레이만 맞고 맞은게 Floor일때
                    transform.position = Vector2.Lerp(current, new Vector2(hitFoot.point.x, PR.velocity.y), time);
                }
            }
            else if ((hit.collider != null && hitFoot.collider != null))
            {   //레이와 발에있는 레이가 둘다 맞았을때 
                if (Mathf.Abs(hit.collider.transform.position.x) < Mathf.Abs(hitFoot.collider.transform.position.x))
                { // 만약 머리에서쏜 레이의 맞은 지점의 x좌표가 발에서 쏜 레이의 맞은 지점의 x좌표보다 절대값이 작을경우 
                    transform.position = Vector2.Lerp(current, new Vector2(hit.point.x, PR.velocity.y), time);
                }
                else if (Mathf.Abs(hit.collider.transform.position.x) > Mathf.Abs(hitFoot.collider.transform.position.x))
                { // 만약 머리에서 쏜 레이의 맞은 지점의 x좌표가 발에서 쏜 레이의 맞은 지점의 x좌표보다 절대값이 클 경우
                    transform.position = Vector2.Lerp(current, new Vector2(hitFoot.point.x, PR.velocity.y), time);
                }
                else if (Mathf.Abs(hit.collider.transform.position.x) == Mathf.Abs(hitFoot.collider.transform.position.x))
                {  // 머리와 발의 레이가 맞은 지점의 x좌표 절대값이 둘다 같을떄
                    transform.position = Vector2.Lerp(current, new Vector2(hitFoot.point.x, PR.velocity.y), time);
                }
            }
            else
            {
                transform.position = Vector2.Lerp(current, dest, time);
            }
            yield return null;
        }
        isDash = false;
        isDashing = false;
        animator.SetBool("dash", false);
    }
    #endregion
}
