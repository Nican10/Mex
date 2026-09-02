using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaBoss : MonoBehaviour
{
    public int vida = 1000;

    Animator anim;

    public bool vulneravel = false;

    public float tempoVulneravel;

    
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void ReceberDano(int dano)
    {
        if (!vulneravel)
        {
            return;
        }

        anim.Play("bosshit");

        vida -= dano;

        Debug.Log("Vida do Boss: " + vida);
        
        if (vida <= 0)
        {

            GetComponent<boss>().enabled = false;

            anim.Play("bossdie");

            Destroy(gameObject, 1f);
        }

    }   

    public void AtivarVulnerabilidade()
    {
        if (vulneravel)
        {
            return;
        }
        vulneravel = true;

        Debug.Log("Boss vulnerável");

        
        Invoke(nameof(DesativarVulnerabilidade), tempoVulneravel);

        
    }

    void DesativarVulnerabilidade()
    {
        vulneravel = false;

        Debug.Log("Boss protegido novamente");
    }

}
