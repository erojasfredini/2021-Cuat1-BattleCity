using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    private NavMeshAgent agente;
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        objetivo = transform.position;
    }

    public float distanciaLlegada = 1.0f;
    private Vector3 objetivo = new Vector3();
    public Transform[] puntosPatrulla;
    void Update()
    {
        if ((transform.position - objetivo).magnitude < distanciaLlegada)
        {
            //NavMeshHit hit;
            //do
            //{
            //    objetivo = new Vector3(Random.Range(0.0f, 20.0f),
            //    Random.Range(0.0f, 20.0f),
            //    Random.Range(0.0f, 20.0f));
            //} while (!NavMesh.SamplePosition(objetivo, out hit, 100.0f, 0));
            //objetivo = hit.position;
            objetivo = puntosPatrulla[Random.RandomRange(0, puntosPatrulla.Length - 1)].position;

            agente.SetDestination(objetivo);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(objetivo, 1.0f);
    }
}
