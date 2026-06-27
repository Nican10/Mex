using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolim : MonoBehaviour
{
    private Animator anim;

    public float impulso = 15f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.Play("trampolim");
        }

        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, impulso);
    }
}
