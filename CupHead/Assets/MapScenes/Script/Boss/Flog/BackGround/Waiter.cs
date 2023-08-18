using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waiter : MonoBehaviour
{

    private Image image;

    bool LRChk = true;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x < -14)
        {
         
            LRChk = false;
            LRChange();
        }
        if(gameObject.transform.position.x > 14)
        {
    
            LRChk = true;
            LRChange();
        }


        if (LRChk)// ÁÂ¿ì ÀÌµ¿
        {
            transform.Translate(Vector3.left * 3 * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * 3 * Time.deltaTime);
        }
       
    }

    void LRChange()
    {
        Vector3 newScale = image.rectTransform.localScale;
        newScale.x *= -1f;
        image.rectTransform.localScale = newScale;
    }
}
