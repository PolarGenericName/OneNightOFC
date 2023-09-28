using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    private AudioSource audioSource;
    private static Audiomanager instance;
    private bool isMenuMusicPlaying = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (isMenuMusicPlaying)
        {
            PlayMenuMusic();
        }
    }

    private void Update()
    {
        // Verifica se a música terminou de tocar e a reinicia.
        if (!audioSource.isPlaying && isMenuMusicPlaying)
        {
            PlayMenuMusic();
        }
    }

    public void PlayMenuMusic()
    {
        // Certifique-se de que o áudio esteja configurado no componente AudioSource.
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    public void StopMenuMusic()
    {
        audioSource.Stop();
        isMenuMusicPlaying = false;
    }
}
