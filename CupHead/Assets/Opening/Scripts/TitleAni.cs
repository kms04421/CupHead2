using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAni : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator. GetCurrentAnimatorStateInfo(0).IsName("Title")&&
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >=1.0f)
        {
            gameObject.SetActive(false);
        }
    }



}
