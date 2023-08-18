using System.Collections.Generic;
using UnityEngine;

public class Boss3_idle : MonoBehaviour
{
    public GameObject Eye; //����
    public GameObject carrotFly; // ���ƿ����� ���
    public GameObject carrotBoom;// �����̻���
    public GameObject ring;// ������
    public GameObject charge;//����
    public GameObject carrotFlyEmpty; // ����� ���� �θ�
    public GameObject Boss3mpty;
    List<GameObject> ringList = new List<GameObject>();
    List<GameObject> carrotFlyList = new List<GameObject>();
    List<GameObject> carrotBoomList = new List<GameObject>();


    public AudioClip ringAudio;

    public AudioClip chargeAudio;

    public AudioClip dieAudio;

    private AudioSource audioSource;

    private GameObject inputGameObj; // ������ ������Ʈ 
    private Transform target;
    private float atkTime = 0; //���ݽð�
    private float setTime = 0;
    private int atkCount = 0;
    private int allAtkCount = 0;
    private Animator animator;
    private int atkType = 0; // ���� Ÿ�� 

    private int BossHp = 100;
    Vector2 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        setTime = 3;
        animator = GetComponent<Animator>();

        //���ƿ����� ���
        for (int i = 0; i < 4; i++)
        {
            inputGameObj = Instantiate(carrotFly);
            carrotFlyList.Add(inputGameObj);
            carrotFlyList[i].SetActive(false);
            carrotFlyList[i].transform.SetParent(carrotFlyEmpty.transform);
        }

        //������� ����Ʈ
        for (int i = 0; i < 10; i++)
        {
            inputGameObj = Instantiate(carrotBoom);
            carrotBoomList.Add(inputGameObj);
            carrotBoomList[i].SetActive(false);

        }
        for (int i = 0; i < 5; i++)
        {
            inputGameObj = Instantiate(ring, new Vector3(transform.position.x, transform.position.y + 1.7f, 0), Quaternion.identity);
            ringList.Add(inputGameObj);
            ringList[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        atkTime += Time.deltaTime;
        if (BossHp < 0)
        {
            audioSource.PlayOneShot(dieAudio);
            animator.SetTrigger("Die");

        }
        else
        {

            if (atkTime > setTime)
            {
                if (atkType == 0)// ���� ���
                {
                    setTime = 4;
                    carrotBoomAtk();
                    atkTime = 0;

                    atkType = Random.Range(0, 2);
                }
                else if (atkType == 1)// ������
                {
                    setTime = 2;

                    animator.SetBool("Shoot", true);

                    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

                    if (stateInfo.IsName("carrot_shoot_transition") && stateInfo.normalizedTime > 1f) // ������ �غ�
                    {

                        audioSource.PlayOneShot(chargeAudio);
                        animator.SetBool("Shat", true);

                        Eye.SetActive(true);

                    }
                    if (stateInfo.IsName("carrot_shoot") && stateInfo.normalizedTime > 1f)//������ ����
                    {
                        if (atkCount == 0)
                        {
                            audioSource.PlayOneShot(ringAudio);
                            target = FindObjectOfType<Test>().transform; // Ÿ�� ������
                            targetPos = new Vector2(target.position.x, target.position.y); // Ÿ�� ��ġ ����

                            charge.SetActive(true);
                            setTime = 0.5f;
                            atkTime = 0;
                            atkCount++;
                            return;
                        }
                        if (atkCount < 6)
                        {
                            charge.SetActive(false);
                            atkCount++;
                            RingAtk();
                            setTime = 0.1f;
                            atkTime = 0;
                        }
                        else
                        {

                            audioSource.Stop();
                            allAtkCount++;
                            atkCount = 0;
                            if (allAtkCount == 3)
                            {
                             
                                Eye.SetActive(false);
                                animator.SetBool("Shoot", false);
                                animator.SetBool("Shat", false);
                                allAtkCount = 0;
                                atkType = Random.Range(0, 2);
                            }
                        }



                    }

                }



            }

            for (int i = 0; i < 4; i++) // ������� �����غ�
            {
                if (carrotFlyList[i].transform.position.y > 7f)
                {
                    if (carrotFlyList[i].activeSelf)
                    {
                        carrotFlyList[i].SetActive(false);
                        for (int j = 0; j < carrotBoomList.Count - 1; j++)
                        {
                            if (!carrotBoomList[j].activeSelf)
                            {
                                carrotBoomList[j].transform.position = carrotFlyList[i].transform.position;
                                carrotBoomList[j].SetActive(true);
                                break;
                            }
                        }
                    }

                }

            }

        }


    }
    Vector2[] vectorList = new Vector2[]
      {
            new Vector3 (-5, -3,0),
            new Vector3 (-8, -4,0),
            new Vector3 (5, -2,0),
            new Vector3 (8, -1, 0)
      }; // ���� ����Ʈ 

    //���ƿ����� ��ټ���
    private void carrotBoomAtk()
    {

        int rnad1 = Random.Range(0, 2);
        int rnad2 = Random.Range(2, 4);

        carrotFlyList[0].transform.position = vectorList[rnad1]; // ���ƿ����� ��� ��ġ����
        carrotFlyList[1].transform.position = vectorList[rnad2];
        carrotFlyList[0].SetActive(true);
        carrotFlyList[1].SetActive(true);
        carrotFlyList.Reverse();

    }

    private void RingAtk()
    {
        for (int i = 0; i < ringList.Count; i++)
        {
            if (!ringList[i].activeSelf)
            {

                Vector2 ringVector = new Vector2(transform.position.x, transform.position.y + 1.7f);

                ringList[i].transform.position = ringVector; //Ring ��ġ ����

                Vector2 directionToTarget = targetPos - ringVector;


                float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

                ringList[i].transform.rotation = targetRotation;
                ringList[i].SetActive(true);
                break;
            }
        }
    }
}
