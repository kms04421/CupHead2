using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.InputSystem.XR.Haptics;
using Unity.VisualScripting;
using UnityEngine.Animations;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject title;
    public GameObject Dark;
    public GameObject PressAnyKey;
    public GameObject End;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Title")
            && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >=1.0f)
        {
            title.SetActive(false);
            Dark.SetActive(false);
            PressAnyKey.SetActive(true);
            //animator = GetComponent<Animator>();
        }

        bool log = animator.GetCurrentAnimatorStateInfo(0).IsName("Title");
        Debug.LogFormat("{0}",log );
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("End")
           && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {

            Debug.LogFormat(" 어디보자 ");
            PressAnyKey.SetActive(false);
            End.SetActive(false);
        }
        
      
    }
}
