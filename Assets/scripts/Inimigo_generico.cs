using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo_generico : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    [SerializeField]
    float velocidadeMovimento;

    [SerializeField]
    private Rigidbody2D rigidbody2D;


    void Update()
    {
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;
        Vector2 direcao = posicaoAlvo - posicaoAtual;
        direcao = direcao.normalized;
        
        this.rigidbody2D.velocity = (this.velocidadeMovimento * direcao);
    }
}
