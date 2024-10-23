using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public Transform spawnPoint; // Punto específico donde aparecerá el enemigo
    public float spawnInterval = 2f; // Intervalo de aparición (en segundos)
    [SerializeField] private Puntaje puntaje; // Referencia al sistema de puntaje

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
        // Instanciar el enemigo
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Obtener el script Enemigo del enemigo generado
        Enemigo enemigoScript = newEnemy.GetComponent<Enemigo>();

        // Asignar el puntaje al enemigo
        if (enemigoScript != null)
        {
            enemigoScript.SetPuntaje(puntaje);
        }
    }
}
