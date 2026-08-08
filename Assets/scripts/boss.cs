using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float velocidadeInimigo = 5f;

    private Rigidbody2D rb;      

    private Animator anim;

    public Transform visual;      

    public Transform player;

    public float distanciaPerseguir = 20f;

    public float tempoParadoAposHit = 1f;

    private float timerParado = 0f;

    private vidaBoss vidaBossScript;

    public float timerSlam = 0f;

    public float intervaloSlam = 5f;

    private bool segundaFase = false;

    private bool preparandoSlam = false;

    public float forcaPulo = 24f;

    private bool fazendoSlam = false;

    public float forcaPulo2 = 36f;

    private bool fezDoubleJump = false;

    private Vector2 alvoSalto;

    public float intensidadeMira = 2f;

    public GameObject spikePrefab;

    public float limiteXmin = 17;
    public float limiteXmax = 38;

    public float posicaoYInicialSpike = 12f;

    public float tempoSpike = 2f;


    // Start is called before the first frame update
    void Start()
    {

        anim = visual.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        vidaBossScript = GetComponent<vidaBoss>();

    }

    // Update is called once per frame
    void Update()
    {

        if (timerParado > 0)
        {
            timerParado -= Time.deltaTime;

            rb.velocity = new Vector2(0, rb.velocity.y);

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("bosshit"))
            {
                anim.Play("bossparado");
            }

            return;
        }

        AtualizarSlam();
        AtualizarPerseguicao();
        
               
    } 
    public void IniciarTempoParado()
    {
        timerParado = tempoParadoAposHit;
    }

    private void AtualizarPerseguicao()
    {
        if (preparandoSlam)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        if (fazendoSlam)
        {
            return;
        }

        if (player != null)
        {
            float distancia = Vector2.Distance(transform.position, player.position);

            if (distancia <= distanciaPerseguir)
            {
                if (player.position.x > transform.position.x)
                {
                    visual.localScale = new Vector3(2.2993f, 2.2993f, 2.2993f);
                }
                else
                {
                    visual.localScale = new Vector3(-2.2993f, 2.2993f, 2.2993f);
                }
                Vector2 direcao = (player.position - transform.position).normalized;

                rb.velocity = new Vector2(direcao.x * velocidadeInimigo, rb.velocity.y);

                anim.Play("bossandando");
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    private void AtualizarSlam()
    {
        if(!segundaFase && vidaBossScript.vida <= 8500)
        {
           segundaFase = true;
        }

        if (!segundaFase)
            return;

        if (fazendoSlam)
        {
            MirarNoAlvo();
            AtualizarDirecaoPlayer();
        }

        //faz double jump

        if (fazendoSlam && !fezDoubleJump && rb.velocity.y <= 0)
        {
            fezDoubleJump = true;
            anim.Play("bossdouble");

            alvoSalto = player.position;

            rb.velocity = new Vector2(rb.velocity.x, 0f);
            MirarNoAlvo();
            rb.AddForce(Vector2.up * forcaPulo2, ForceMode2D.Impulse);
      
        }

        if (fazendoSlam && fezDoubleJump && rb.velocity.y <= 0)
        {
            
            anim.Play("bossslam");
        }

        //enquanto esta preparando o slam nao conta o tempo para o proximo

        if(preparandoSlam || fazendoSlam)
            return;

        timerSlam += Time.deltaTime;

        if (timerSlam >= intervaloSlam)
        {
            timerSlam = 0;

            preparandoSlam = true;

            anim.Play("bosspreparo");

            Invoke("IniciarJump", 1f);
        }
        
    }

    private void IniciarJump()
    {
        preparandoSlam = false;
        fazendoSlam = true;

        anim.Play("bossjump");

        alvoSalto = player.position;  
     
        rb.velocity = Vector2.zero;

        MirarNoAlvo();

        rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);

        Debug.Log("PULO VELOCIDDDADE " + rb.velocity);

    }

    private void MirarNoAlvo()
    {
        float distanciaX = alvoSalto.x - transform.position.x;

        if (Mathf.Abs(distanciaX) > 0.1f)
        {
            rb.velocity = new Vector2(distanciaX * intensidadeMira, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);   
        }
    }

    private void AtualizarDirecaoPlayer()
    {
        if (player == null)
            return;

        if(player.position.x > transform.position.x)
        {
            visual.localScale = new Vector3(2.2993f, 2.2993f, 2.2993f);
        }
        else if (player.position.x < transform.position.x)
        {
            visual.localScale = new Vector3(-2.2993f, 2.2993f, 2.2993f);
        }
    }

    private void CriarSpike()
    {
        if (spikePrefab == null)
            return;
        
        float posicaoX = Random.Range(limiteXmin, limiteXmax);

        Vector3 posicao = new Vector3(posicaoX, posicaoYInicialSpike, 0f);

        GameObject spike = Instantiate(spikePrefab, posicao, Quaternion.identity);

        Destroy(spike, tempoSpike );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (fazendoSlam && collision.gameObject.CompareTag("Chao"))  
        {
           Debug.Log("resetou double");

            fazendoSlam = false;           
            fezDoubleJump = false;
            timerSlam = 0;

            CriarSpike();
        }
    }

}
