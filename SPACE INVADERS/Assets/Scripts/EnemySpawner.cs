using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public Transform spawnPoint; // Punto espec�fico donde aparecer� el enemigo
    public float spawnInterval = 2f; // Intervalo de aparici�n (en segundos)

    private float timeSinceLastSpawn = 0f;

    public void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f; // Reinicia el contador
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}