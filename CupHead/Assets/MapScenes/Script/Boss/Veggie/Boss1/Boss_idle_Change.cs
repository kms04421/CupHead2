using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_idle_Change : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boss_idle;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            boss_idle.SetActive(true);
            gameObject.SetActive(false);

        }
    }
}
