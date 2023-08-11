using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    private float width;
    private float speed = 3f;
    private void Awake()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();  // �ڽ��ݸ��� 2d ����������
        width = boxCollider.size.x/100; // �ڽ��ݸ��� �� x���� 100������  
      
    }
  
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // ������Ʈ �������� ���ǵ常ŭ �̵�      

        if (transform.position.x*0.5 <= -width) // ���� ������Ʈ�� ������ *0.5���� -width�� Ŀ���ų� ��������  
        {
           
            Reposition();
        }
    }
    //���� ������Ʈ�� width*4��ŭ �̵� 
    private void Reposition()
    {
        Vector2 offset = new Vector2(width*4f, 0);
        transform.position = (Vector2) transform.position + offset;
    }
}
