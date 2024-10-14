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

        if (VidaActual <= 0)
        {
            Morir();  // Llamar al método de morir si la vida es 0 o menos
        }
    }   

    // Método para morir
    private void Morir()
    {
        Debug.Log("El personaje ha muerto.");
        // Aquí puedes agregar lógica para la muerte, como reproducir una animación o destruir el objeto
        // Destroy(gameObject);
    }

    // Cuando empieza a colisionar con un enemigo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            if (corutinaDanio == null)
            {
                // Inicia la corutina para recibir daño constante mientras esté en contacto con el enemigo
                corutinaDanio = StartCoroutine(RecibirDanioContinuo(10, 1f));
            }
        }
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

            // Detenemos la corutina si ya no está en contacto con el enemigo
            if (corutinaDanio != null)
            {
                StopCoroutine(corutinaDanio);
                corutinaDanio = null;
            }
        }
    }

    // Corutina para recibir daño constante
    private IEnumerator RecibirDanioContinuo(int cantidadDanio, float intervalo)
    {
        // Mientras esté en contacto con un enemigo, se ejecuta el ciclo
        while (enContactoConEnemigo)
        {
            RecibirDanio(cantidadDanio); // Reduce vida
            yield return new WaitForSeconds(intervalo); // Espera antes de volver a hacer daño
        }
    }
}
