using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida_Player : MonoBehaviour
{

    public int vida;
    public int vidaMaxima;

    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;  

   
    void Start()
    {
     
    }

    void Update()
    {
        HealthLogic();
    }
    void HealthLogic()
    {
        if(vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }
        for (int i = 0; i < coracao.Length; i++)
        {
            if(i < vida)
            {
                coracao[i].sprite = cheio;   
            }
            else
            {
                coracao[i].sprite = vazio;
            }


            if(i < vidaMaxima)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }
    }
   
}
