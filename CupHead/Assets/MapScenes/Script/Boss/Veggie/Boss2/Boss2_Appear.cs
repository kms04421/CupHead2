using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Appear : MonoBehaviour
{
    float AppearTime = 0.0f;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        AppearTime += Time.deltaTime;
        if (AppearTime <= 0.7f)
        {
            
            if (AppearTime >= 0.3f)
            {
                transform.Translate(Vector3.down * 6 * Time.deltaTime); // ������Ʈ �������� 3��ŭ �̵�  
            }
            else
            {
                transform.Translate(Vector3.up * 11 * Time.deltaTime); // ������Ʈ �������� 3��ŭ �̵�  
            }

        }
        else
        {
            Boss.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
