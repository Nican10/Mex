using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaDoInimigo : MonoBehaviour
{
    public int vida = 100;

    Animator anim;

    public bool tomandoDano;

    public string animacaoHit;
    
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();       
    }

    public void ReceberDano(int dano)
    {
        tomandoDano = true;

        anim.Play(animacaoHit);

        vida -= dano;

        Debug.Log("Vida do Inimigo: " + vida);

        Invoke("PararDano", 1f);

        if( vida <= 0 )
        {
            tomandoDano = true;

            GetComponent<inimigoPatrulha>().enabled = false;

            anim.Play(animacaoHit);
                        
            Destroy(gameObject, 1f);
        }
    }

    void PararDano()
    {
        tomandoDano = false;
    }
   
}
