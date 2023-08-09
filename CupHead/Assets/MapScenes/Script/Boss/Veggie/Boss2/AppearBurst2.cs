using UnityEngine;
using UnityEngine.UIElements;

public class AppearBurst2 : MonoBehaviour
{
    // Start is called before the first frame update
    RectTransform rectTransform;
    float AppearTime = 0.0f;
    private Animator animator;
    public GameObject onion;
    public GameObject GroundBack;
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
        if (AppearTime <= 2f)
        {
            if (AppearTime >= 1.5f)
            {
                Vector2 currentSize = rectTransform.sizeDelta;

                currentSize.y += 0.5f;
                rectTransform.sizeDelta = currentSize;
                transform.Translate(Vector3.up * 2 * Time.deltaTime); // 오브젝트 위쪽으로 3만큼 이동  
            }

        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f) // 애니메이션 퍼센트 체크
        {
            if(potatoActive == false)
            {
                onion.SetActive(true);
             
                potatoActive = true;
            }
            
            

        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.69f) // 애니메이션 퍼센트 체크
        {


            GroundBack.SetActive(true);

        }

    }
  
}
