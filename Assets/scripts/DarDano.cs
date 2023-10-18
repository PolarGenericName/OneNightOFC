using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarDano : MonoBehaviour
{
    public Vida_Player heart;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            heart.vida--;
        }
    }
}
