using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstMove : MonoBehaviour
{
    public AudioClip Wormdie; // ������

    private CircleCollider2D collider2D;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<CircleCollider2D>();  
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * 10 * Time.deltaTime); // ������Ʈ �������� 3��ŭ �̵�      
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
