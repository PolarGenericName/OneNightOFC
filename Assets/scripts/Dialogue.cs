using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;
    public List<Sprite> expressions; // Lista de expressões faciais correspondentes

    private bool isDialogActive = false;
    private bool canAdvanceText = false;
    private float textAdvanceDelay = 0.5f;
    
    public LayerMask playerLayer;
    public float radious;

    private DialogueControl dc;
    bool onRadious;

    private int currentExpressionIndex = 0; // Índice da expressão facial atual

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    private IEnumerator EnableTextAdvance()
    {
        yield return new WaitForSeconds(textAdvanceDelay);
        canAdvanceText = true;
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
            dc.SetExpression(expressions[currentExpressionIndex]);
            currentExpressionIndex++;
            }
            else
            {
                if (!isAdvancingText)
                {
                    dc.NextSentence();
                    // Atualize a expressão facial com base no índice atual da frase
                    if (currentExpressionIndex < expressions.Count)
                    {
                        dc.SetExpression(expressions[currentExpressionIndex]);
                        currentExpressionIndex++;
                    }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && isDialogActive)
        {
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