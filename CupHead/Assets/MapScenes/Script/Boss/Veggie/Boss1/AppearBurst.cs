using UnityEngine;
using UnityEngine.UIElements;

public class AppearBurst : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform rectTransform;
    float AppearTime = 0.0f;
    private Animator animator;
    public GameObject potato;

    public AudioClip audioClip; // 오디오 클립 설정

    private AudioSource audioSource; // 오디오 소스 컴포넌트

    private bool potatoActive = false;
    private void Start()
    {
        // 오디오 소스 컴포넌트 가져오기
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
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f) // 애니메이션 퍼센트 체크
        {
            if(potatoActive == false)
            {
                potato.SetActive(true);
              
                potatoActive = true;
            }
            
            
        }

        
    }
  
}
