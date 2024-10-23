using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float vida = 100f;
    [SerializeField] private int dañoAlJugador = 20;
    [SerializeField] private float cantidadPuntos = 10;
    
    private Puntaje puntaje; // Referencia al sistema de puntaje

    private Transform player;

    private void Start()
    {
        // Busca automáticamente al jugador en la escena usando su tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
            // Sumar puntos al destruir al enemigo
            if (puntaje != null)
            {
                puntaje.SumarPuntos(cantidadPuntos);
            }
            Destroy(gameObject); // Destruye al enemigo si su vida llega a 0
        }
    }

    // Asignar el puntaje dinámicamente
    public void SetPuntaje(Puntaje puntajeReferencia)
    {
        puntaje = puntajeReferencia;
    }
}
