using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_shot : MonoBehaviour
{
    private float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // ������Ʈ �������� ���ǵ常ŭ �̵�   
    }
}
