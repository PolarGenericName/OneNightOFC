using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public Spawmanager spawnManager; // Arraste o objeto que contém o script "Spawmanager" aqui na janela de inspetor.
    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasSpawned)
        {
            spawnManager.StartSpawn(); // Chama um novo método StartSpawn no SpawnManager.
            hasSpawned = true;
        }
    }
}
