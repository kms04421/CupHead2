using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public int input;
    public int hor;
    public int ver;
    public bool isDash;     //shift
    public bool isAim;      //c
    public bool isAttack;   //x
    public bool isUltimate; //v
    public bool isJump;     //z

    
    void Update()
    {
        hor = GetAxis("Horizontal");
        ver = GetAxis("Vertical");
        isDash = GetKeyDown("shift");
        isAim = GetKeyDown("c");
        isAttack = GetkeyDown("x");
        isUtimate = GetKeyDown("v");
        isJump = GetKeyDown("z");
    }
}
