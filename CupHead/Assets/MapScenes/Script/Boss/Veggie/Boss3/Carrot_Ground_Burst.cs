using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot_Ground_Burst : MonoBehaviour
{
    public GameObject GroundBurstBack;

    public AudioClip ground_Burst;
    private AudioSource audioSource;
    private bool ground_Burst_Chk =false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (ground_Burst_Chk)
        {
            audioSource.PlayOneShot(ground_Burst);
            ground_Burst_Chk =true;
        }

      
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if(stateInfo.normalizedTime >= 0.7f)
        {
            GroundBurstBack.SetActive(true);
        }
    }
}
