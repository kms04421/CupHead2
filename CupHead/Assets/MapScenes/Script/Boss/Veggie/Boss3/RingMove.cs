using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMove : MonoBehaviour
{
    private CircleCollider2D collider2D;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<CircleCollider2D>();


        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right* 7.5f * Time.deltaTime);
        if (transform.position.x > 7f || transform.position.x < -7f)
        {
            animator.SetBool("Die", true);
        }
        if (transform.position.x > 8f || transform.position.x < -8f)
        {
            animator.SetBool("Die", false);
            gameObject.SetActive(false);
        }
        if (transform.position.y < -2)
        {
            animator.SetBool("Die",true);
        }
        if(transform.position.y < -3)
        {
            animator.SetBool("Die", false);
            gameObject.SetActive(false);
        }

    }

   
}
