using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public float forcaQuicar = 6f;

    private Rigidbody2D rb;
    private bool jaQuicou = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ignora collisao fisica com inimgos,inclluindo os filhos do boss
        if (collision.gameObject.CompareTag("Inimigo"))
        {
           Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);

            return;
        }

        //quica qnd bate no chao
        if (!jaQuicou && collision.gameObject.CompareTag("Chao"))
        {
            jaQuicou = true;

            rb.velocity = new Vector2(rb.velocity.x, forcaQuicar);
        }

    }
}
