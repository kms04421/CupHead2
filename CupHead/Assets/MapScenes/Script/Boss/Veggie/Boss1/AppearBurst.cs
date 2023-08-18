using UnityEngine;
using UnityEngine.UIElements;

public class AppearBurst : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform rectTransform;
    float AppearTime = 0.0f;
    private Animator animator;
    public GameObject potato;

    public AudioClip audioClip; // ����� Ŭ�� ����

    private AudioSource audioSource; // ����� �ҽ� ������Ʈ

    private bool potatoActive = false;
    private void Start()
    {
        // ����� �ҽ� ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();


        rectTransform = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();

        audioSource.PlayOneShot(audioClip);
    }

    // Update is called once per frame
    void Update()
    {
        
        AppearTime += Time.deltaTime;
        if (AppearTime >= 2.8f)
        {
            if (AppearTime <= 3f)
            {
                Vector2 currentSize = rectTransform.sizeDelta;

                currentSize.y += 2.5f;
                rectTransform.sizeDelta = currentSize;
            }




        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f) // �ִϸ��̼� �ۼ�Ʈ üũ
        {
            if(potatoActive == false)
            {
                potato.SetActive(true);
              
                potatoActive = true;
            }
            
            
        }

        
    }
  
}
