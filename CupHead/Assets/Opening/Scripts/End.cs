using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private Animator animator;
    public GameObject PressAnyKey;
    public GameObject Select;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("End") && stateInfo.normalizedTime >= 1.0f)
        {
            Debug.Log("들어오니?");
            PressAnyKey.SetActive(false);
            Select.SetActive(true);
        }
    }
}
