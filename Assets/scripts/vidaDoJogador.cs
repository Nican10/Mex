using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaDoJogador : MonoBehaviour
{
    public int vida = 100;

    private bool podeTomarDano = true;

    public bool tomandoDano = false;

    private Animator anim;

    private SpriteRenderer sprite;

    
    void Start()
    {
        anim = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();

        tomandoDano = false;
    }

    public void ReceberDano(int dano)
    {
        if (!podeTomarDano)
            return;

        vida -= dano;

        Debug.Log("Vida atual: " + vida);

        tomandoDano = true;

        anim.Play("recebendodano");        

        if (vida <= 0)
        {
            Debug.Log("Voce morreu");

            StopAllCoroutines();

            tomandoDano = true;

            GetComponent<controle>().enabled = false;

            anim.Play("recebendodano");

            FindObjectOfType<gameOver>().MostrarGameOver();

            StartCoroutine(Morte());

            return;
        }

        StartCoroutine(Invencibilidade());     


    }

    IEnumerator Morte()
    {
        yield return new WaitForSeconds(1f);

        GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<SpriteRenderer>().enabled = false;

    }

    IEnumerator Invencibilidade()
    {
        podeTomarDano = false;

        for (int i = 0; i < 5; i++)
        {
            sprite.color = Color.clear;

            yield return new WaitForSeconds(0.1f);

            sprite.color = Color.white;

            yield return new WaitForSeconds((0.1f));
        }
        podeTomarDano = true;

        tomandoDano = false;
    }
}
