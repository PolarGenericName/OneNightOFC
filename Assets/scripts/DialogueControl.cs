using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [Header("Components")]

    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]

    public float typingSpeed;
    private string[] sentences;
    private int index;

    [Header("Sounds")]
    public AudioClip typingSound;

    private bool isTyping; // Adicionada vari�vel para controlar se o texto est� sendo digitado

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        index = 0; // Redefina o �ndice do texto para o in�cio
        StartCoroutine(TypeSentence());
    }

    public void CloseDialogue()
    {
        dialogueObj.SetActive(false);
        speechText.text = ""; // Limpa o texto ao fechar o di�logo
        isTyping = false; // Define isTyping como false ao fechar o di�logo
        // Voc� pode adicionar outras a��es de fechamento, se necess�rio
    }

    IEnumerator TypeSentence()
    {
        isTyping = true; // Define isTyping como true ao iniciar a digita��o
        foreach (char letter in sentences[index].ToCharArray())
        {
            if (!isTyping) break; // Se o di�logo for fechado, interrompa a digita��o
            speechText.text += letter;
            audioSource.PlayOneShot(typingSound);
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false; // Define isTyping como false ao terminar a digita��o
    }

    public void NextSentence()
    {
        if (isTyping) // Verifica se o texto est� sendo digitado
        {
            // Se estiver digitando, conclui a digita��o imediatamente
            isTyping = false;
            speechText.text = sentences[index]; // Exibe o texto completo
        }
        else
        {
            if (speechText.text == sentences[index])
            {
                if (index < sentences.Length - 1)
                {
                    index++;
                    speechText.text = "";
                    StartCoroutine(TypeSentence());
                }
                else
                {
                    speechText.text = "";
                    index = 0;
                    dialogueObj.SetActive(false);
                }
            }
        }
    }
}
