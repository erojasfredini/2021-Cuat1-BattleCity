using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    void Start()
    {
    }

    public Transform torreta;
    public float velocidad = 1.0f;
    public GameObject prefabBala;
    public Transform origenBala;
    public float potenciaBala = 1.0f;
    private float t;
    private bool f;

    void Update()
    {
        t = Input.GetAxis("Turret");
        f = Input.GetButtonDown("Fire1");

        if (f)
        {
            GameObject bala = GameObject.Instantiate(prefabBala, origenBala.position, origenBala.rotation);
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            rb.velocity = origenBala.forward * potenciaBala;
        }
    }

    void FixedUpdate()
    {
        torreta.Rotate(Vector3.up, t * velocidad * Time.fixedDeltaTime);
    }
}
