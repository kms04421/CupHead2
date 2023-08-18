using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static BossManager instance;

    private float animatorTime = 0f;
    private float setTime = 3;
    private int atkChk = 1;

    public int BossChk = 0;// 보스 공격패턴

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animatorTime += Time.deltaTime;
        if (BossChk == 0)
        {
            if(animatorTime > setTime)
            {
                animatorTime = 0;
                if (atkChk%2 == 0)
                {
                    BossChk = 1;
                }
                else
                {
                    BossChk = 2;
                }
            }
        }
    }

    public void AtkChange()
    {
        if(BossChk != 0)
        {
            BossChk = 0;
            atkChk++;
        }
       
    }
}
