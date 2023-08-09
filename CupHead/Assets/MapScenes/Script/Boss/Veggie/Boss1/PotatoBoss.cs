using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEditor;
using UnityEngine;

public class PotatoBoss : MonoBehaviour
{
    private float AttackTime = 0f;
    private float BossSecondsTime = 0f;
    private Animator animator;
    public GameObject BossAtK1; // 흙1
    public GameObject BossAtK2; // 지렁이
    public GameObject Boss2;
    List<GameObject> list;
    int AtkCount = 1;
    float[] AtkCountList;
    float[] AllAtkCountList;
    int AllAtkCount = 0;
    Vector2 vector2;

    private float BossHp;
    // Start is called before the first frame update
    void Start()
    {
        BossHp = 0;
        AllAtkCountList = new float[] { 0.8f, 1.3f, 1.8f};
        AtkCountList = new float[] { 0f, 0.18f, 0.5f, 0.8f, 3f } ;
        list = new List<GameObject>();
        BossSecondsTime = Random.Range(5, 8);
        animator = GetComponent<Animator>();
       
        vector2= new Vector2( transform.position.x-3 , transform.position.y-3);
        for (int i = 0; i <= 2; i++)
        {
            if (i < 2)
            {
                GameObject gameObject = Instantiate(BossAtK1, vector2, Quaternion.identity);
                list.Add(gameObject);

            }
            else
            {
                GameObject gameObject1 = Instantiate(BossAtK2, vector2, Quaternion.identity);
                list.Add(gameObject1);
            }
           
           list[i].SetActive(false);
           
           
        }
        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BossHp <= 0)
        {          
            animator.SetTrigger("die");
            StartCoroutine(die());
            
        }

        AttackTime += Time.deltaTime;
        if(BossSecondsTime <= AttackTime)
        {
          
            animator.SetBool("Attack", true); // 공격 애니메이션 실행
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            Debug.Log( stateInfo.IsName("Boss_idle"));
            animator.speed = AllAtkCountList[AllAtkCount];
            if (stateInfo.IsName("Boss_Attack") && stateInfo.normalizedTime >= AtkCountList[AtkCount] && stateInfo.normalizedTime <= 1f) // 정규화된 시간이 1 이상이면 애니메이션이 종료
            {
                Debug.Log(stateInfo.normalizedTime);
                AttackBurst();
                AtkCount++;
            }

            
            if (stateInfo.IsName("Boss_Attack") && stateInfo.normalizedTime >= 1f)
            {              
                animator.SetBool("Attack", false);// 공격 애니메이션 끝
                animator.speed = 0.8f;
                AtkCount = 0;
                BossSecondsTime = Random.Range(2f, 4f);
                AttackTime = 0f;
                AllAtkCount++;
            }
            if(AllAtkCount == 3)
            {
               
                AllAtkCount = 0;
            }


        }
        

    }


    private void AttackBurst()
    {
     switch(AtkCount)// 보스 공격 카운터에 따라 발사
        {
            case 1:
            list[0].SetActive(true);
            StartCoroutine(rollBack(0));
            break;
            case 2:
            list[1].SetActive(true);
            StartCoroutine(rollBack(1));
            break;
            case 3:
            list[2].SetActive(true);
            StartCoroutine(rollBack(2));
            break;
        }

            
    }

    private IEnumerator rollBack(int num) // 보스공격 원위치로 
    {
        yield return new WaitForSeconds(2f);
        list[num].transform.position = vector2;
        list[num].SetActive(false);

    }

    private IEnumerator die()
    {
        yield return new WaitForSeconds(3f);
        transform.Translate(Vector3.down * 4 * Time.deltaTime);
        yield return new WaitForSeconds(3f);
        Transform parentTransform = transform.parent;
        Boss2.SetActive(true);
        parentTransform.gameObject.SetActive(false);
      
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 총알명
        if(collision.tag.Equals("Peshooter")) 
        {
            BossHp -= 1;
        }

    }
}
