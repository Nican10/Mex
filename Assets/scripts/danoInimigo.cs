using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoInimigo : MonoBehaviour
{
    public int dano = 50;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<vidaDoJogador>().ReceberDano(dano);
        }
    }
}
