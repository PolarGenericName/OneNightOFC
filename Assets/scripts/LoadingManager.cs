using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingManager : MonoBehaviour
{
    public string Scene;  // O nome da cena que será carregada
    public float loadingDelay = 3.5f; // Tempo de espera em segundos

    private void Start()
    {
        // Inicie o carregamento da cena em uma coroutine
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator LoadAsyncScene()
    {
        // Espere pelo tempo especificado
        yield return new WaitForSeconds(loadingDelay);

        // Crie uma operação de carregamento assíncrono para a cena
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Scene);

        // Aguarde até que a cena esteja totalmente carregada
        yield return asyncLoad;
    }
}