using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot_Fly : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // ¿Ãµø
        transform.Translate(Vector3.up * 3 * Time.deltaTime);
       

   
    }
}
