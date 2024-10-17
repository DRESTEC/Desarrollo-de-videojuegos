using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RotacionArma : MonoBehaviour
{
    [Header("movimientoCamara")]
    private Vector3 objetivo;
    [SerializeField] private Camera camara;
    [SerializeField] private float anguloInicial;

    private SpriteRenderer spriteRenderer;
  private void Start()
    {
        // Obtenemos la referencia al SpriteRenderer del arma
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update(){
        objetivo = camara.ScreenToWorldPoint(Input.mousePosition);
        float anguloRadianes = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x);
        float anguloGrados = (180 / Mathf.PI * anguloRadianes);
        transform.rotation = Quaternion.Euler(0,0, anguloGrados); 

         transform.rotation = Quaternion.Euler(0, 0, anguloGrados);

        // Si el ángulo es mayor a 90 grados o menor a -90 grados, volteamos el sprite en Y
        if (anguloGrados > 90 || anguloGrados < -90)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }
}