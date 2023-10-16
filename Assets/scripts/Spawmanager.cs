using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawmanager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject enemy;
    [SerializeField] int maxEnemyCount = 10; // Defina o limite máximo de inimigos desejado.

    private int currentEnemyCount = 0;
    private bool isSpawning = false;

    void Start()
    {
        // Remova o InvokeRepeating.
    }

    public void StartSpawn()
    {
        isSpawning = true;
        StartCoroutine(SpawnEnemiesRepeatedly());
    }

    private IEnumerator SpawnEnemiesRepeatedly()
    {
        while (isSpawning && currentEnemyCount < maxEnemyCount)
        {
            int index = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[index].position, Quaternion.identity);
            currentEnemyCount++;
            yield return new WaitForSeconds(1.5f); // Ajuste o intervalo conforme necessário.
        }
    }
}