using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    Animator animator;
    public GameObject End;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            End.SetActive(true);
            Debug.Log("??");
        }
    }
}
