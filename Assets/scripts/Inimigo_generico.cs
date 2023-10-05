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
    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    //mecanica de raio de visão
    [SerializeField]
    private float raioDeVisao;


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position , this.raioDeVisao);
    }
    private void ProcurarJoagadorl()
    {
        Physics2D.OverlapCircle(this.transform.position, this.raioDeVisao);
    }

    void Update()
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

            this.rigidbody2D.velocity = (this.velocidadeMovimento * direcao);
            //flip de sprite
            if (this.rigidbody2D.velocity.x > 0)
            {
                this.spriteRenderer.flipX = false;
            }
            else if (this.rigidbody2D.velocity.x < 0)
            {
                this.spriteRenderer.flipX = true;
            }
        }
        else
        {
            this.rigidbody2D.velocity = Vector2.zero;
        }
   
}
}
