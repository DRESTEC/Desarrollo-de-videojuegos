using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float vida = 100f;
      [SerializeField] private int dañoAlJugador = 20;

    private Transform player;

    private void Start()
    {
        // Busca automáticamente al jugador en la escena usando su tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Mueve el enemigo hacia el jugador
        if (player != null)
        {
            // Dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Mueve al enemigo hacia el jugador
            transform.position += direction * speed * Time.deltaTime;

            // Rotación del enemigo para que mire al jugador
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle); // Para 2D, rotamos sobre el eje Z
        }
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el objeto con el que colisionamos tiene el tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reducir la vida del jugador
            MovimientoPJ playerController = collision.gameObject.GetComponent<MovimientoPJ>();
            if (playerController != null)
            {
                playerController.RecibirDanio(dañoAlJugador);
            }

            Debug.Log("El jugador ha sido dañado por un enemigo.");
        }
    }

    // Método para recibir daño
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruye al enemigo si su vida llega a 0
        }
    }
     
        public void RecibirDanio(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Destroy(gameObject); // Destruye al enemigo si su vida llega a 0
        }
    }


    // Método para recibir daño
 
}
