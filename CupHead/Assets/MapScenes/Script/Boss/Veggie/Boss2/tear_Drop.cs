using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class tear_Drop : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    public AudioClip die;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y < -2.5f)
        {
            animator.SetBool("Die", true);
            audioSource.PlayOneShot(die);
        }

       if(transform.position.y < -3.35)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);//�ִϸ��̼� ���� ���� �ޱ� 

            if (stateInfo.IsName("Onion_tear_dropEnd") && stateInfo.normalizedTime > 1f) // �̸��� �ش�ִϸ��̼��̸鼭 ����� 100%�ΰ�
            {
                gameObject.SetActive(false);
            }
            if (stateInfo.IsName("Onion_tear_pinkEnd1") && stateInfo.normalizedTime > 1f)
            {
                gameObject.SetActive(false);
            }

            gameObject.transform.position = gameObject.transform.position; // ���ڸ����� ����


        }
        else
        {
            transform.Translate(Vector3.down * 4 * Time.deltaTime); // ������Ʈ �������� 3��ŭ �̵�    
            animator.SetBool("Die", false);

            
          
            
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag.Equals("PinkBossAtk"))
        {
            animator.SetTrigger("PlayerPinkAtk");
            

            //playó��

            //
        }
    }
}
