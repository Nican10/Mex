using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuriken : MonoBehaviour
{
    public float velocidade = 10f;

    public int dano = 50;

    private Rigidbody2D rb;
    private Animator anim;

    public float direcao = 1f;

    
    void Start()
    {
        anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(direcao * velocidade, 0f);
                
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo") && collision.isTrigger == false)
        {
            vidaDoInimigo inimigo = collision.GetComponent<vidaDoInimigo>();

            if (inimigo != null)
            {
                inimigo.ReceberDano(dano);
            }

            vidaBoss boss = collision.GetComponent<vidaBoss>();

            if (boss != null)
            {
                boss.ReceberDano(dano);
            }
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Parede"))
        {
            Destroy(gameObject);
        }

    }
    
}
