using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    //private GameObject bala;

    void CancelarCoolDown()
    {
        puedoDisparar = true;
        //Debug.Log("CancelarCoolDown");
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
    private Camera cam;
    void Start()
    {
        //bala = GameObject.Instantiate(prefabBala, origenBala.position, origenBala.rotation);
        //bala.SetActive(false);

        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }

    private Quaternion rotacionObjetivo;

    void Update()
    {
        Ray rayPicking = cam.ScreenPointToRay(Input.mousePosition);
        //Debug.Log($"Origen {rayPicking.origin} | Direccion {rayPicking.direction}");
        RaycastHit hit;
        int mascara = (1 << LayerMask.NameToLayer("Pisos"));
        bool colisiono = Physics.Raycast(rayPicking, out hit, 100.0f, mascara);
        if (colisiono)
        {
            //Debug.Log($"Colisiono contra {hit.collider.name} | En posicion {hit.point}");
            Vector3 dir = (hit.point - torreta.position);
            dir.y = 0.0f;
            dir.Normalize();
            Debug.Log($"Direccion {dir}");
            rotacionObjetivo = Quaternion.LookRotation(dir, Vector3.up);
        }

        t = Input.GetAxis("Turret");
        f = Input.GetButtonDown("Fire1");

        //if (f && !bala.active)
        //if (f && puedoDisparar)
        //{
        //    Invoke("CancelarCoolDown", cooldownDisparo);
        //    puedoDisparar = false;
        //    Rigidbody rbTanque = GetComponent<Rigidbody>();
        //    GameObject bala = GameObject.Instantiate(prefabBala, origenBala.position, origenBala.rotation);
        //    //bala.SetActive(true);
        //    //bala.transform.position = origenBala.position;
        //    //bala.transform.rotation = origenBala.rotation;
        //    Rigidbody rb = bala.GetComponent<Rigidbody>();
        //    rb.velocity = origenBala.forward * potenciaBala + rbTanque.velocity;
        //}
    }

    public float velocidadRotacion = 1.0f;
    void FixedUpdate()
    {
        torreta.rotation = Quaternion.Slerp(torreta.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);
        //torreta.Rotate(Vector3.up, t * velocidad * Time.fixedDeltaTime);
    }
}
