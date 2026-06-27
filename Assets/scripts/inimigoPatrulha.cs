using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoPatrulha : MonoBehaviour
{
    public float velocidadeInimigo = 5f;

    private Rigidbody2D rb;

    public bool indoDireita = true;

    public Transform verificaChao;

    public float distanciaChao = 1f;

    public LayerMask camadaChao;

    private Animator anim;

    public Transform visual;

    private bool podeVirar = true;

    public visaoInimigo visao;

    public Transform visaoTransform;

    public GameObject arma;
    public Transform pontoDisparo;
    public float tempoEntreTiros = 1f;
    public float proximoTiro;

    public string inimigoAndando;


    // Start is called before the first frame update
    void Start()
    {
        
        anim = visual.GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool temChao = Physics2D.Raycast(verificaChao.position, Vector2.down, distanciaChao, camadaChao);
        
        if (!temChao && podeVirar)
       {
            podeVirar= false;

            Virar();

            Invoke("LiberarVirada", 0.2f);
                     
        }

        if (GetComponent<vidaDoInimigo>().tomandoDano)
            {
                rb.velocity = new Vector2 (0, rb.velocity.y);
                return;
            }

        if (visao != null && visao.jogadorDetectado)
        {
            rb.velocity = Vector2.zero;

            anim.Play("inimigoataque");

            if (Time.time >= proximoTiro)
            {
                GameObject tiro = Instantiate(arma, pontoDisparo.position, Quaternion.identity);

                if (indoDireita)
                {
                    tiro.GetComponent<projetilInimigo>().direcao = 1f;
                }
                else
                {
                    tiro.GetComponent<projetilInimigo>().direcao = -1f;
                }

                proximoTiro = Time.time + tempoEntreTiros;
            }

            return;
        }
            if(indoDireita)
            {
                rb.velocity = new Vector2(velocidadeInimigo, rb.velocity.y);
                visual.localScale = new Vector3(1, 1, 1);
              
                anim.Play(inimigoAndando);
            }   
            else
            {
                rb.velocity = new Vector2(-velocidadeInimigo, rb.velocity.y);
                visual.localScale = new Vector3(-1, 1, 1);
               
                anim.Play(inimigoAndando);
            }

               
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Virar"))
        
        {
            
            Virar();

            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Parede") || collision.gameObject.CompareTag("Inimigo"))
        {
            Virar();
        }
    }

    void LiberarVirada()
    {
        podeVirar = true;
    }

    void Virar()
    {
        indoDireita = !indoDireita;

        if (indoDireita)
        {
            verificaChao.localPosition = new Vector3(0.5f, verificaChao.localPosition.y, 0f);

            if(visaoTransform != null)
            {
                visaoTransform.localPosition = new Vector3(5.6f, visaoTransform.localPosition.y, 0f);
            }
            if(pontoDisparo != null)
            {
                pontoDisparo.localPosition = new Vector3(1.25f, pontoDisparo.localPosition.y, 0f);
            }
        }
        else
        {
            verificaChao.localPosition = new Vector3(-0.5f, verificaChao.localPosition.y, 0f);

            if (visaoTransform != null)
            {
                visaoTransform.localPosition = new Vector3(-5.6f, visaoTransform.localPosition.y, 0f);
            }
            
            if (pontoDisparo != null)
            {
                pontoDisparo.localPosition = new Vector3(-1.25f, pontoDisparo.localPosition.y, 0f);
            }
        }
    }
}
