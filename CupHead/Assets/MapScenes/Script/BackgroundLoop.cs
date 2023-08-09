using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;
    private float speed = 3f;
    private void Awake()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();  // 박스콜린더 2d 정보가졍옴
        width = boxCollider.size.x/100; // 박스콜린더 의 x값에 100나누기  
      
    }
  
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // 오브젝트 왼쪽으로 스피드만큼 이동      

        if (transform.position.x*0.5 <= -width) // 현재 오브젝트의 포지션 *0.5보다 -width가 커지거나 같아질때  
        {
           
            Reposition();
        }
    }
    //현재 오브잭트를 width*4만큼 이동 
    private void Reposition()
    {
        Vector2 offset = new Vector2(width*4f, 0);
        transform.position = (Vector2) transform.position + offset;
    }
}
