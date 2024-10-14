using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyMovement : MonoBehaviour
{
    public Transform Player; // Asigna al jugador desde el inspector o por c�digo
    public float speed = 5f;

    void Update()
    {
        // Mueve el enemigo hacia el jugador
        if (Player != null)
        {
            Vector3 direction = (Player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
              float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle); // Para 2D, rotamos sobre el eje Z
        }
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el objeto con el que colisionamos tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destruimos al jugador (el objeto con el tag "Player")
            FindAnyObjectByType<GameOver>().MostrarGameOver();
            Debug.Log("El jugador ha sido destruido por un enemigo.");
        }
    }
  
 
}
