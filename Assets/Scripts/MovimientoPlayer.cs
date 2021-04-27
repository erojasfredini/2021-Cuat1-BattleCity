using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    /// <summary>
    /// La velocidad lineal
    /// </summary>
    public float velocidadLineal = 3.0f;
    public float velocidadRotacion = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private Rigidbody rb;
    private float h;
    private float v;
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        rb.angularVelocity = h * transform.up * velocidadRotacion;
        rb.velocity = v * transform.forward * velocidadLineal + Vector3.up * rb.velocity.y;
    }
}
