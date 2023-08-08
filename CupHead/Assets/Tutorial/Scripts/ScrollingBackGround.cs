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

       /* if (!((Player.instance.isBlocked == true) || (Player.instance.isAim == true)))
        {
            if (Player.instance.dirX > 0)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            if (Player.instance.dirX < 0)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }*/
     
    }
}
