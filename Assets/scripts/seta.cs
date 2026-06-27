using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seta : MonoBehaviour
{
    private Animator anim;

    private bool ativou;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !ativou)
        {
            ativou = true;

            anim.Play("setahit");

            Destroy(gameObject, 0.4f);
        }
    }
}
