using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformatrap : MonoBehaviour
{
    private Animator anim;

    private bool ativou;

    public float tempo;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !ativou)
        {
            ativou = true;

            anim.Play("plataformasumindo");

            Destroy(gameObject, tempo);
        }
    }
}
