using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPJ : MonoBehaviour
{
    [SerializeField] private float Velocidad;
    [SerializeField] private int VidaMaxima = 100;

    private Rigidbody2D Movimiento;
    private Animator animator;
    private SpriteRenderer spritePJ;
    private int VidaActual;
 
    private bool enContactoConEnemigo = false; // Bandera para saber si está en contacto con un enemigo
    private Coroutine corutinaDanio; // Para almacenar la corutina del daño
    private Coroutine corutinaDañoContinuo; // Para controlar la corutina
    

    private void Awake()
    {
        Movimiento = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spritePJ = GetComponentInChildren<SpriteRenderer>();
        VidaActual = VidaMaxima;
    }

    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Movimiento.velocity = new Vector2(Horizontal, Vertical) * Velocidad;
        animator.SetFloat("Camina", Mathf.Abs(Movimiento.velocity.magnitude));

        if (Horizontal > 0)
        {
            spritePJ.flipX = false;
        }
        else if (Horizontal < 0)
        {
            spritePJ.flipX = true;
        }
    }

    public void RecibirDanio(int cantidad)
    {
        VidaActual -= cantidad;  // Reducir la vida
        Debug.Log("vida actual:  "+ VidaActual);
        if (VidaActual <= 0)
        {
            Morir();  // Llamar al método de morir si la vida es 0 o menos
        }
    }   

    // Método para morir
    private void Morir()
    {
        Debug.Log("El personaje ha muerto.");
        FindAnyObjectByType<GameOver>().MostrarGameOver();
        Debug.Log("El jugador ha sido destruido por un enemigo.");
    }
 
   

    // Mientras sigue en contacto con el enemigo
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            enContactoConEnemigo = true;
        }
    }

    // Cuando deja de colisionar con un enemigo
    private void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Enemigo"))
    {
        enContactoConEnemigo = false;
        // Si se deja de tocar al enemigo, detener la corutina
        if (corutinaDañoContinuo != null)
        {
            StopCoroutine(corutinaDañoContinuo);
            corutinaDañoContinuo = null;
        }
    }
}

    // Corutina para recibir daño constante
    private IEnumerator RecibirDanioContinuo(int cantidadDanio, float intervalo)
{
    // Mientras esté en contacto con un enemigo, se ejecuta el ciclo
    while (enContactoConEnemigo)
    {
        GetComponent<MovimientoPJ>().RecibirDanio(cantidadDanio); // Reduce vida en el script MovimientoPJ
        yield return new WaitForSeconds(intervalo); // Espera 2 segundos antes de volver a hacer daño
    }
}
    
}
