using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPointAndClick : MonoBehaviour
{
    private NavMeshAgent agente;
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    private Vector3 target = new Vector3();
    void Update()
    {
        bool isClick = Input.GetMouseButton(0);
        var rayo = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayo, out RaycastHit colision, 100.0f))
        {
            target = colision.point;
            Debug.Log($"Point to {target}");
            if (isClick)
            {
                agente.SetDestination(target);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(target, 1.0f);
    }
}
