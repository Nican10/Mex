using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dano : MonoBehaviour
{
    public int quantidadeDeDano = 50;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        vidaDoJogador jogador = collision.GetComponent<vidaDoJogador>();
               
        if ( jogador != null )
        {
            jogador.ReceberDano(quantidadeDeDano);
        }
    }
}
