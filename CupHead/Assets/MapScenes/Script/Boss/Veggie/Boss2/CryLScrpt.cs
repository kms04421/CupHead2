using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryLScrpt : MonoBehaviour
{

    private RectTransform rectTransform;

     void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Vector3 scale = rectTransform.localScale;
        scale.x *= -1;
        rectTransform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
