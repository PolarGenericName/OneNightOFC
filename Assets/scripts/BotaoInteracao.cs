using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoInteracao : MonoBehaviour
{
    public GameObject interactButton;

    void OnTriggerEnter2D(Collider2D collision)
    {
        interactButton.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        interactButton.SetActive(false);
    }
}


