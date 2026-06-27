using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueJogador : MonoBehaviour
{
    public Transform areaAtaque;
    public float raioAtaque = 1f;

    public int danoAtaque = 30;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Atacar();
        }
    }

    void Atacar()
    {
        Collider2D[] inimigos = Physics2D.OverlapCircleAll(areaAtaque.position, raioAtaque);

        foreach(Collider2D inimigo in inimigos)
        {
            vidaDoInimigo vida = inimigo.GetComponent<vidaDoInimigo>();

            if (vida != null)
            { 
                vida.ReceberDano(danoAtaque);
            }
        }
    }
}
