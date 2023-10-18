using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroler : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject playerGM;
    Animator anim;
    bool isAlive = true;
    private bool isAttacking = false;
    float attackDistance = 1f;

 

    void Start()
    {
        playerGM = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
         if (playerGM != null && isAlive)
        {
        // Obtém a posição do jogador e a posição do inimigo
        Vector2 playerPos = playerGM.transform.position;
        Vector2 enemyPos = transform.position;

        // Calcula a diferença em X
        float deltaX = playerPos.x - enemyPos.x;

        // Verifica a direção em que o jogador está em relação ao inimigo
        if (deltaX > 0)
        {
            // Jogador à direita do inimigo
            transform.rotation = Quaternion.Euler(0, 0, 0); // Sem rotação
        }
        else
        {
            // Jogador à esquerda do inimigo
            transform.rotation = Quaternion.Euler(0, 180, 0); // Rotação de 180 graus no eixo Y
        }



            transform.position = Vector2.MoveTowards(transform.position, playerGM.transform.position, speed * Time.deltaTime);
            float distanceToPlayer = Vector2.Distance(transform.position, playerGM.transform.position);

            if (distanceToPlayer < attackDistance)
            {
                isAttacking = true;
            }
            else
            {
                isAttacking = false;
            }
        
            anim.SetBool("Attack", isAttacking);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pedra"))
        {
            anim.SetTrigger("Death");
            isAlive = false;
            Destroy (gameObject, 0.6f);
        }
    }
}