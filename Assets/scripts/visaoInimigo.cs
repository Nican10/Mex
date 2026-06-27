using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visaoInimigo : MonoBehaviour
{
    public bool jogadorDetectado;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jogadorDetectado = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jogadorDetectado = false;
           
        } 
    }
}
