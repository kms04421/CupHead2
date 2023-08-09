using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot_Ground_Burst : MonoBehaviour
{
    public GameObject GroundBurstBack;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if(stateInfo.normalizedTime >= 0.7f)
        {
            GroundBurstBack.SetActive(true);
        }
    }
}
