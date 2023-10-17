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

    }
   
}
