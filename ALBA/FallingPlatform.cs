using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float fallTime = 0.5f, destroyTime = 2f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void OnCollisionEnter2D(Collision col)
    {
        if(col.gameObject.tag == "Player")
        {
           
            Destroy(rb, destroyTime);
        }
    }

 
}
