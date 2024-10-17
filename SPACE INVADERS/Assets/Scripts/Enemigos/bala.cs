using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
     [SerializeField] private float velocidad;
     [SerializeField] private float daño; 
     
    [SerializeField] private float tiempoDeVida = 2f;
    // Update is called once per frame

        void Start()
    {
        // Destruir la bala automáticamente después de 'tiempoDeVida' segundos
        Destroy(gameObject, tiempoDeVida);
    }

    void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Enemigo"))
        {
            other.GetComponent<Enemigo>().TomarDaño(daño);
            Destroy(gameObject);
        } 
    }
}
