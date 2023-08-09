using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAppear1 : MonoBehaviour
{
    public GameObject appear1;
    public GameObject appear2;


    private float appearTime = 0f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        appearTime += Time.deltaTime;
        if (appearTime > 1f)
        {
            if (appear1.transform.position.y <= 0f)
            {
                appear1.SetActive(true);
                appear1.transform.Translate(Vector3.up * 10 * Time.deltaTime);


            }
            else
            {
             
                appear1.SetActive(false);
                appear2.SetActive(true);
                enabled = false;
                
            }
        }
        


    }
}
