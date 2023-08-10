using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.InputSystem.XR.Haptics;
using Unity.VisualScripting;
using UnityEngine.Animations;
using UnityEditor.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public Animator animatorTitle;
    public Animator animatorPress;
    //public Animator animatorEnd;
    public GameObject title;
    public GameObject Dark;
    public GameObject PressAnyKey;
    public GameObject End;
    public GameObject PressText;
    private Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Instance = this;
        title.SetActive(true);
        Dark .SetActive(true);
        PressAnyKey.SetActive(false);
    }

    public void OnAnimationComplete()
    {
        title.SetActive(false);
        Dark.SetActive(false);
        PressAnyKey.SetActive(true);
        PressText.SetActive(true);
        animatorPress.Play("HeadMug");
    }
    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Title") && stateInfo.normalizedTime >= 0.98f && stateInfo.normalizedTime <= 1.0f)
        {
            OnAnimationComplete();
        }
        if (stateInfo.IsName("Title") && stateInfo.normalizedTime >= 1.1f)
        {
            if (Input.anyKeyDown)
            {
                PressText.SetActive(false);
                End.SetActive(true);
            }
        }
    }
}
