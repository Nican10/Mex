using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyplataforma : MonoBehaviour
{
    private int pontoAtual;

    private bool ativou;
    public Transform[] pontos;
    public Transform pontoSegurar;

    private GameObject player;
    private bool playerAgarrado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            playerAgarrado = true;

            player.GetComponent<controle>().podeAtirar = false;
            
            ativou = true;

        }
    }
    private void Update()
    {
        if(ativou)
        {
            transform.position = Vector2.MoveTowards(transform.position, pontos[pontoAtual].position, 5f * Time.deltaTime);
                        
        }

        if (Vector2.Distance(transform.position, pontos[pontoAtual].position) < 0.1f)
        {
            ativou = false;
            playerAgarrado = false;

            player.GetComponent<controle>().podeAtirar = true ;

            pontoAtual = 1 - pontoAtual;
        }

        if (playerAgarrado)
        {
            player.transform.position = pontoSegurar.position;
        }
       
    }
}
