using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{
    [SerializeField] private Transform origenBalas;
    [SerializeField] private GameObject bala;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Disparar();
        }
    }
    private void Disparar(){
        Quaternion rotacionBala = origenBalas.rotation * Quaternion.Euler(0, 0, -90); // Corrige 90 grados si está mal orientada
        Instantiate(bala, origenBalas.position, rotacionBala);

         
    }
}
