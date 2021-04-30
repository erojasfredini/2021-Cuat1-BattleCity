using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    void Start()
    {
        //bala = GameObject.Instantiate(prefabBala, origenBala.position, origenBala.rotation);
        //bala.SetActive(false);
    }
    //private GameObject bala;

    void CancelarCoolDown()
    {
        puedoDisparar = true;
        Debug.Log("CancelarCoolDown");
    }

    public Transform torreta;
    public float velocidad = 1.0f;
    public GameObject prefabBala;
    public Transform origenBala;
    public float potenciaBala = 1.0f;
    private float t;
    private bool f;

    public float cooldownDisparo = 0.1f;
    private bool puedoDisparar = true;

    void Update()
    {
        t = Input.GetAxis("Turret");
        f = Input.GetButtonDown("Fire1");

        //if (f && !bala.active)
        if (f && puedoDisparar)
        {
            Invoke("CancelarCoolDown", cooldownDisparo);
            puedoDisparar = false;
            Rigidbody rbTanque = GetComponent<Rigidbody>();
            GameObject bala = GameObject.Instantiate(prefabBala, origenBala.position, origenBala.rotation);
            //bala.SetActive(true);
            //bala.transform.position = origenBala.position;
            //bala.transform.rotation = origenBala.rotation;
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            rb.velocity = origenBala.forward * potenciaBala + rbTanque.velocity;
        }
    }

    void FixedUpdate()
    {
        torreta.Rotate(Vector3.up, t * velocidad * Time.fixedDeltaTime);
    }
}
