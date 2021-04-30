using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    public float distancia = 10.0f;
    public Transform objetivo;
    public float velocidad = 1.0f;
    private float distanciaFisica = 10.0f;
    private Camera c;

    void Start()
    {
        c = GetComponent<Camera>();
        c.orthographic = true;
        c.orthographicSize = distancia;
    }

    void FixedUpdate()
    {
        c.orthographicSize = distancia;

        var target = objetivo.position + objetivo.up * distanciaFisica;
        transform.position = Vector3.Lerp(transform.position, target, velocidad * Time.deltaTime);
    }
}
