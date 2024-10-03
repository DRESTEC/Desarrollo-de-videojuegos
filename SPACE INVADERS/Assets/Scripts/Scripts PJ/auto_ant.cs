using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public Transform Player; // Asigna al jugador desde el inspector o por código
    public float speed = 5f;

    void Update()
    {
        // Mueve el enemigo hacia el jugador
        if (Player != null)
        {
            Vector3 direction = (Player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}