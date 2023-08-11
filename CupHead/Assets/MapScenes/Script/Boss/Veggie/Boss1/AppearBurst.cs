using UnityEngine;
using UnityEngine.UIElements;

public class AppearBurst : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rectTransform;
    float AppearTime = 0.0f;
    private Animator animator;
    public GameObject potato;

    private bool potatoActive = false;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();

     
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
