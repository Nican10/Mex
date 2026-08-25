using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coletavel : MonoBehaviour
{
    private Animator anim;

    private bool coletado;

    public int valorScore = 100;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !coletado)
        {
            coletado = true;

            gameManager.instance.score += valorScore;        
            Debug.Log("Score atual" + gameManager.instance.score);

            anim.Play("coletou");

            Destroy(gameObject, 0.5f);
        }
    }
    
}
