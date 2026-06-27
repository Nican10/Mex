using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff : MonoBehaviour
{
    public bool coletado;
    
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player") && !coletado)
        {
            coletado = true;

            collision.GetComponent<controle>().buffAtivo = true;
            collision.GetComponent<controle>().Invoke("DesativarBuff", 6f);

            Destroy(gameObject);
        }
    }
}
