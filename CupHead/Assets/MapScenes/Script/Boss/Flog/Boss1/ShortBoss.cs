using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortBoss : MonoBehaviour
{
    private Animator animator;


    private float animatorTime = 0f;
    private float setTime = 500f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.IsName("shortFrog") && stateInfo.normalizedTime >= 0.99f)
        {
          animator.SetTrigger("Idle");
        }


        if (BossManager.instance.BossChk == 2) // true일때 Tallfrog 패턴사용
        {
            animatorTime += Time.deltaTime;

            animator.SetBool("Atk1", true);
            AnimatorStateInfo stateInfoAtk = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("ShortFrogAtk") && stateInfo.normalizedTime >= 0.99f)
            {
                animator.SetBool("Atk2", true);
                setTime = 5;
            }
            if (animatorTime > setTime)
            {
                animatorTime = 0;
                animator.SetBool("Atk3", true);
            }
            if (stateInfo.IsName("ShortFrogAtk3") && stateInfo.normalizedTime >= 0.99f)
            {
                animator.SetBool("Atk1", false);
                animator.SetBool("Atk2", false);
                animator.SetBool("Atk3", false);
                setTime = 500f;

                BossManager.instance.AtkChange();
            }

        }
    }
}
