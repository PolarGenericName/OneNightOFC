using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Inimigo_generico : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    [SerializeField]
    float velocidadeMovimento;

    [SerializeField]
    private float distanciaMinima;

    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    //mecanica de raio de visão
    [SerializeField]
    private float raioDeVisao;


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position , this.raioDeVisao);
    }
    private void ProcurarJoagador()
    {
       Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioDeVisao);

        if (colisor != null)
        {
            this.alvo = colisor.transform;
        }
        else
        {
            this.alvo = null;
        }
    }

    void Update()
    {
        ProcurarJoagador();
        
        if(this.alvo != null)
        {
            Mover();
        }
        else
        {
            PararDeMover();
        }
        
    }
    private void Mover()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;
        //calcula distancia minima pro player
        float distancia = Vector2.Distance(posicaoAtual, posicaoAlvo);

        if (distancia >= this.distanciaMinima)
        {
            //movimenta inimigo
            Vector2 direcao = posicaoAlvo - posicaoAtual;
            direcao = direcao.normalized;

            this.rigidbody.velocity = (this.velocidadeMovimento * direcao);
            //flip de sprite
            if (this.rigidbody.velocity.x > 0)
            {
                this.spriteRenderer.flipX = false;
            }
            else if (this.rigidbody.velocity.x < 0)
            {
                this.spriteRenderer.flipX = true;
            }
        }
        else
        {
            PararDeMover();
        }


    }
    private void PararDeMover()
    {
        this.rigidbody.velocity = Vector2.zero;
        //add dps script de animaçao
    }
}
