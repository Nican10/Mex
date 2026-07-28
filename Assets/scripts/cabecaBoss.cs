using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cabecaBoss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            vidaBoss vida = GetComponentInParent<vidaBoss>();
            boss bossScript = GetComponentInParent<boss>();


            vida.AtivarVulnerabilidade();
            bossScript.IniciarTempoParado();
              
        }
    }    
}
