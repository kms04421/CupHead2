using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;
using UnityEngine.XR;

public class ScrollingBackGround : MonoBehaviour
{
    public float speed = 2f;
    private float xInput;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (PlayerController.instance.hor == 1)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (PlayerController.instance.hor == -1)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }*/
    }
}
