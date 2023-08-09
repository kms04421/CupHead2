using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageTransition : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public float transitionDuration = 3.0f;
    public static ImageTransition instance;
    
    private void Start()
    {
        // 시작할 때 이미지2를 투명하게 설정
        image2.color = new Color(1, 1, 1, 0);
        StartCoroutine(TransitionImages());
        instance = this;
    }

    IEnumerator TransitionImages()
    {
        float elapsed = 0f;

        while (elapsed < transitionDuration)
        {
            elapsed += Time.deltaTime;
            float normalizedTime = elapsed / transitionDuration;

            // image1은 페이드 아웃
            image1.color = new Color(1, 1, 1, 1 - normalizedTime);

            // image2는 페이드 인
            image2.color = new Color(1, 1, 1, normalizedTime);

            yield return null;
        }
    }
}
