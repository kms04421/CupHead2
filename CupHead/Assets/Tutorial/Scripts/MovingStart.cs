using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStart : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            /*  if (gameObject.GetComponent<ScrollingBackGround>() == true)
              {
                  gameObject.GetComponent<ScrollingBackGround>().enabled = false;
              }
              else if(gameObject.GetComponent<ScrollingBackGround>() == false)
              {
                  gameObject.GetComponent<ScrollingBackGround>().enabled = true;
              }*/
            ScrollingBackGround sbg = gameObject.GetComponent<ScrollingBackGround>();

            if (sbg != null)
            {
                sbg.enabled = !sbg.enabled; // Toggle the enabled status
            }
        }
    }
}
