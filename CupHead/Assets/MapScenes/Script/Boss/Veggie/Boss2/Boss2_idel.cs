using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

public class Boss2_idel : MonoBehaviour
{

    float BossHp = 90f;
    private float AttackTime = 0f;
    private float BossSecondsTime = 0f;
    private Animator animator;
    float[] atkCount;
    int allAtkCount = 0;
    bool cryStart = false;
    // 눈물 
    public GameObject cryL;
    public GameObject cryR;
    private List<GameObject> tearSp;
    private GameObject tearObj;
    public GameObject Tear;
    public GameObject Pink_Tear;
    public GameObject Boss3;
    bool bossDie = false;
    void Start()
    {
        tearSp = new List<GameObject>();
        for(int i=0; i < 15;i++ )
        {
            if(i == 3)
            {
                tearObj = Instantiate(Pink_Tear, transform.position, Quaternion.identity);
            }
            else
            {
                tearObj = Instantiate(Tear, transform.position, Quaternion.identity);
                
            }
            tearObj.name = "tear" + i;
            tearObj.SetActive(false);
            tearSp.Add(tearObj);
        }
        atkCount = new float[] { 4f, 5f, 7f };
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        BossHp--;
        AttackTime += Time.deltaTime;

        if(BossHp <=0 && bossDie == false)
        {
            AttackTime = 0;
            animator.SetTrigger("Die");  
          
            bossDie = true;
        }
        if(bossDie && AttackTime > 3)
        {
         
            if(transform.position.y > -3f)
            {
                transform.Translate(Vector3.down * 5f * Time.deltaTime);
            }
            else
            {

            }
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("Onion_die") && stateInfo.normalizedTime >= 0.9f) // 정규화된 시간이 1 이상이면 애니메이션이 종료
            {
              
                animator.SetTrigger("Die2");
           
            }
            if (stateInfo.IsName("Onion_die2") && stateInfo.normalizedTime >= 0.99f) // 정규화된 시간이 1 이상이면 애니메이션이 종료
            {
                Transform parentTransform = transform.parent;
                Boss3.SetActive(true);
                parentTransform.gameObject.SetActive(false);
               
            }
           
                
            if (stateInfo.IsName("Onion_die2") && stateInfo.normalizedTime <= 0.8f)
            {
                

              
            }

        }

        if (AttackTime < 3 && cryStart == false)
        {
            return;
        }
        if (BossHp < 100 && BossHp > 0)
        {
            if (cryStart == false)
            {
                animator.SetTrigger("CryReady");
                cryStart = true;
            }
          
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if(stateInfo.normalizedTime >= 1f)
            {
                animator.SetBool("CryLV1", true);
            }
            
            if (stateInfo.IsName("Onion_Atk") && stateInfo.normalizedTime >= 0.6f && stateInfo.normalizedTime <= 0.7f) // 정규화된 시간이 1 이상이면 애니메이션이 종료
            {
                TearPosition();
                cryL.SetActive(true);
                cryR.SetActive(true);
                
            }
            if (stateInfo.IsName("Onion_Atk") && stateInfo.normalizedTime >= 1f) // 정규화된 시간이 1 이상이면 애니메이션이 종료
            {
       
                animator.SetBool("CryLV2", true);
                AttackTime = 0;
           
            }
            if (stateInfo.IsName("Onion_Atk2") && atkCount[allAtkCount] < AttackTime) // 정규화된 시간이 1 이상이면 애니메이션이 종료
            {
                cryL.SetActive(false);
                cryR.SetActive(false);
                AttackTime = 0;
                tearSp.Reverse();
                animator.SetBool("CryLV3", true);
          

            }
            if (stateInfo.IsName("Onion_AtkEnd") && stateInfo.normalizedTime >= 1f) // 정규화된 시간이 1 이상이면 애니메이션이 종료
            {
              
                Debug.Log("4");
                animator.SetBool("CryLV1", false);
                animator.SetBool("CryLV2", false);
                animator.SetBool("CryLV3", false);
                AttackTime = 0;


            }

        }
        //Debug.Log("여기");
        
    }

    Vector2[] TearSpPosition = new Vector2[] { 
        new Vector2(-8.7f, 5),  new Vector2(-7.7f, 5) , 
        new Vector2(-6.7f, 5) , new Vector2(-4.7f, 5) ,
        new Vector2(-3.7f, 5) , new Vector2(-2.7f, 5) ,
        new Vector2(8.7f, 5),  new Vector2(7.7f, 5) ,
        new Vector2(6.7f, 5) , new Vector2(4.7f, 5) ,
        new Vector2(3.7f, 5) , new Vector2(2.7f, 5)
        ,  new Vector2(-7.7f, 5) ,  new Vector2(-7.7f, 5) 

    };
    int[] RandYList = new int[] { 10, 12, 15 ,20 , 23 };
    private void TearPosition()
    {
        
        int Rand = 0;
        int tearRand = 0;
        int RandY = 0;
        List <int> XList = new List<int>();

        for (int i= 0; i < 6-1; i++)
        {
            tearRand = Random.Range(0, 11);
            if (tearRand > 3) 
            {
                Rand = Random.Range(0, 10);
            }
            else
            {
                continue;
            }
            if(!XList.Contains(Rand))
            {
                XList.Add(Rand);
            }

  
        }

        for (int i = 0; i < XList.Count-1; i++)
        {
          
            RandY = Random.Range(0, 4);
            Vector2 tearPos = new Vector2(TearSpPosition[XList[i]].x, RandYList[RandY]);
            tearSp[i].transform.position = tearPos;
            tearSp[i].SetActive(true);
        }
        }
}
