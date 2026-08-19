using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class controle : MonoBehaviour
{
    public float velocidade = 5f;
    public float pulo = 7f;

    private Rigidbody2D rb;
    private Animator anim;

    public bool estaNoChao;
    public bool estaNaParede;
    private bool usandoPuloDuplo;
    private bool atacando;

    public int quantidadePulos = 2;

    public float velocidadeDeslize = 2f;

    public Vector2 forcaWallJump = new Vector2(8f, 10f);

    public GameObject prefabShuriken;
    public Transform pontoDisparo;
    public int score;
    public TextMeshProUGUI textoScore;
    public bool buffAtivo;
    public bool podeAtirar = true;
    public SpriteRenderer sprite;

    public int danoShurikenBuff = 100;

    public float bounceForce = 10f;
    public int danoStomp = 1;

     

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        sprite = GetComponent<SpriteRenderer>();
                        
    }


    // Update is called once per frame
    void Update()
    {
        float movimento = Input.GetAxis("Horizontal");

        textoScore.text = "Score " + score;
               
        rb.velocity = new Vector2(movimento * velocidade, rb.velocity.y);
        
        if(movimento > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(movimento < 0) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (estaNaParede && !estaNoChao)
        {
            rb.velocity = new Vector2(rb.velocity.x, -velocidadeDeslize);

            
            if (Input.GetKeyDown(KeyCode.W))
            {
                float direcao = transform.localScale.x;

                rb.velocity = new Vector2(-direcao * forcaWallJump.x, forcaWallJump.y);

                usandoPuloDuplo = false;

                estaNaParede = false;
            }
        }


        if (!GetComponent<vidaDoJogador>().tomandoDano)
        {
             //animação do pulo
        if(estaNaParede && !estaNoChao)
        {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("escalando"))
                {
                    anim.Play("escalando");
                }
            
        }
        else if (!estaNoChao && !atacando)
        {
                if (!usandoPuloDuplo)
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("pulando"))
                    {   
                        anim.Play("pulando");
                    }
                }                              
               
        }
        else if(movimento > 0)
        {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("andando"))
                {
                    anim.Play("andando");
                }
            ;
        }
        else if (movimento < 0)
        {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("andando"))
                {
                    anim.Play("andando");
                }
            
        }
        else
        {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("parado"))
                {
                     anim.Play("parado");
                }
           
        }
        }

       

        //pulo
        if (Input.GetKeyDown(KeyCode.W) && quantidadePulos > 0)
        {
            if(quantidadePulos == 2)
            {
                rb.velocity = new Vector2(rb.velocity.x, pulo);

            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, pulo + 2);

            }
            
            quantidadePulos--;

            if (quantidadePulos == 0)
            {
                usandoPuloDuplo = true;

                anim.Play("puloduplo");

                Invoke("PararPuloDuplo", 0.5f);
            }

            estaNoChao = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && podeAtirar)
        {
            atacando = true;

            Invoke("PararAtaque", 0.2f);

            anim.Play("atacando");

            GameObject shuriken = Instantiate(prefabShuriken, pontoDisparo.position, Quaternion.identity);

            if (buffAtivo)
            {
                shuriken.GetComponent<shuriken>().dano = danoShurikenBuff;
            }

            if (buffAtivo)
            {
                shuriken.transform.localScale = new Vector3(3, 3, 3);
            }

            if (transform.localScale.x < 0)
            {
                shuriken.GetComponent<shuriken>().direcao = -1f;

                if (buffAtivo)
                {
                    shuriken.transform.localScale = new Vector3(-3,3,3);
                }
                else
                {
                    shuriken.transform.localScale = new Vector3(-1,1,1);
                }

                
            }
            else
            {
                shuriken.GetComponent<shuriken>().direcao = 1f;

                if (buffAtivo)
                {
                    shuriken.transform.localScale = new Vector3(3,3,3);        
                }
            } 
        }
        if (buffAtivo)
        {
          velocidade = 20f;
        sprite.material.color = Color.cyan;
        }
        else
        {
          velocidade = 5f;
         sprite.material.color = Color.white;
        }        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if(collision.gameObject.CompareTag("Chao"))
        {
           
            estaNoChao = true;
            quantidadePulos = 2;
            usandoPuloDuplo= false;
        }
        if (collision.gameObject.CompareTag("Parede"))
        {
            estaNaParede = true;
        }

        if (collision.gameObject.CompareTag("Inimigo"))
        {
            //verificar se esta caindo(stomp)
            if (rb.velocity.y < 0)
            {
                vidaDoInimigo vida = collision.gameObject.GetComponent<vidaDoInimigo>();

                if (vida != null)
                {
                    vida.ReceberDano(danoStomp);
                }

                //pulo do bounce
                rb.velocity = new Vector2(rb.velocity.x, bounceForce);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Chao"))
        {
            estaNoChao = false;
        }

        if (collision.gameObject.CompareTag("Parede"))
        {
            estaNaParede= false;
        }
    }

   void PararAtaque()
    {
        atacando = false;
    } 

    void PararPuloDuplo()
    {
        usandoPuloDuplo = false;
    }

    void DesativarBuff()
    {
        buffAtivo = false;
    }
}

