using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Boss_Appear_Move : MonoBehaviour
{
    public GameObject bossAppear_2;
    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.up * 10 * Time.deltaTime); // 오브젝트 위쪽으로 3만큼 이동      

        if (transform.position.y >= 0.3f)
        {
            bossAppear_2.SetActive(true);
            gameObject.SetActive(false);
        }
       
      
    }
}
