using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Carrot_Bomb : MonoBehaviour
{
   
    private Transform target;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider2D;
    private Animator animator;

    public AudioClip die;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // SpriteRenderer ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>();
        // �÷��̾� ��ġ ���
        spriteRenderer.flipY = true;
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        //
    }

    // Update is called once per frame
    void Update()
    {
        target = FindObjectOfType<Test>().transform;

        Vector2 directionToTarget = (target.position - transform.position);

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToTarget);

        // ȸ�� ����
        transform.rotation = targetRotation;

        transform.Translate( Vector3.up * 2f * Time.deltaTime);
 


    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        if (collision.tag.Equals("Test"))
        {
            audioSource.PlayOneShot(die);
            animator.SetBool("Die", true);

            StartCoroutine(DelTime());
           
        }
    }

    private IEnumerator DelTime()
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Die", false);
        gameObject.SetActive(false);
    }

}
