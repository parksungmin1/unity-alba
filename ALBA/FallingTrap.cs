using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float forceGravity;
    public GameManager gameManager;
    Rigidbody2D rb;
    public Player player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            rb.isKinematic = false;
            spriteRenderer.color = new Color(1, 1, 1, 1f);
            rb.AddForce(Vector3.down * forceGravity);
         
            Invoke("DeActive", 3);
        }
    }

    void DeActive()
    {
        gameObject.SetActive(false);
    }
}
