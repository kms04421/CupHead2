using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 10 * Time.deltaTime); // 오브젝트 위쪽으로 3만큼 이동      
    }
}
