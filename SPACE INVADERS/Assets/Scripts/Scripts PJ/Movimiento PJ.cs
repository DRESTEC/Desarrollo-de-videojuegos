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

        Movimiento.velocity = new Vector2(Horizontal, Vertical)*Velocidad;
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

    // Detectar colisiones con otros objetos que ataquen al personaje
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            RecibirDanio(10);  // Recibe 10 de daño si choca con un enemigo
        }
    }
}

