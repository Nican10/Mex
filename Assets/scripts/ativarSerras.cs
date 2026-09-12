using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativarSerras : MonoBehaviour
{
    public GameObject serra1;
    public GameObject serra2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            serra1.SetActive(true);
            serra2.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
