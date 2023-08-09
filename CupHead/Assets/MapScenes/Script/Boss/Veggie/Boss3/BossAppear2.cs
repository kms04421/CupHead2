using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear2 : MonoBehaviour
{
    public GameObject appear1;


    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1f)
        {
            gameObject.SetActive(false);
            appear1.SetActive(true);
        }
    }
}
