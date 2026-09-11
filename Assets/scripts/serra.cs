using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serra : MonoBehaviour
{
    private int pontoAtual;

    
    public Transform[] pontos;
    private void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, pontos[pontoAtual].position, 5f * Time.deltaTime);
     
        if (Vector2.Distance(transform.position, pontos[pontoAtual].position) < 0.1f)
        {          

            pontoAtual = 1 - pontoAtual;
        }


    }
}


