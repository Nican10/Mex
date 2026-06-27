using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireplataforma : MonoBehaviour
{
    private Animator anim;

    public float tempo = 1f;

    public float tempoDesligar = 1f;

    public GameObject areaDano;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.Play("fireplataformahit");

            Invoke("AtivarFogo", tempo);

        }
    }
    void AtivarFogo()
    {
        anim.Play("fireplataformaon");

        areaDano.SetActive(true);

        Invoke("DesativarFogo", tempoDesligar);
    }

    void DesativarFogo()
    {
        anim.Play("fireplataformaoff");

        areaDano.SetActive(false);
                
    }
}
