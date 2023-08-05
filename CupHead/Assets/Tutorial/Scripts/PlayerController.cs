using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public int input;
    public float hor;
    public float ver; 
    public bool isDash;     //shift
    public bool isAim;      //c
    public bool isAttack;   //x
    public bool isUltimate; //v
    public bool isJump;     //z

    private void Start()
    {
        instance = this;
    }
    void Update()
    {
        /*hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");*/
    }
    void FixedUpdate()
    {
        /*isDash = Input.GetKeyDown(KeyCode.LeftShift);
        isAim = Input.GetKeyDown(KeyCode.C);
        isAttack = Input.GetKeyDown(KeyCode.X);
        isUltimate = Input.GetKeyDown(KeyCode.V);
        isJump = Input.GetKeyDown(KeyCode.Z);*/
    }
}
