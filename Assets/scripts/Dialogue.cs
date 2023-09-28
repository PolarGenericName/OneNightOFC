using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;
    private bool isDialogActive = false;
    private bool canAdvanceText = false;
    private float textAdvanceDelay = 0.5f; // Ajuste o tempo de atraso conforme necessário

    public LayerMask playerLayer;
    public float radious;

    private DialogueControl dc;
    bool onRadious;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }
    private IEnumerator EnableTextAdvance()
    {
        // Aguarde o tempo de atraso antes de permitir o avanço do texto
        yield return new WaitForSeconds(textAdvanceDelay);
        canAdvanceText = true; // Permita o avanço do texto
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && onRadious)
        {
            if (!isDialogActive)
            {
                isDialogActive = true;
                dc.Speech(profile, speechTxt, actorName);
                // Configure o atraso antes de permitir que o jogador avance no texto
                StartCoroutine(EnableTextAdvance());
            }
            else
            {
                // Se o diálogo já estiver ativo e não estiver avançando para a próxima frase,
                // avance para a próxima frase
                if (!isAdvancingText)
                {
                    dc.NextSentence();
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && isDialogActive)
        {
            // Fecha completamente o diálogo ao pressionar a tecla de espaço
            isDialogActive = false;
            dc.CloseDialogue();
        }
    }

    private void FixedUpdate()
    {
        Interact();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

        if (hit != null)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
    private bool isAdvancingText = false;

}