using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;



public class SeguirObjeto : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    private NavMeshAgent navMeshAgent;

    private void Star()
    {
          navMeshAgent = GetComponent<NavMeshAgent>();
          navMeshAgent.updateRotation = false;
          navMeshAgent.updateUpAxis = false;

          
    }
}