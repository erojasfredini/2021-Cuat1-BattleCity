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
    private float t;

    void Update()
    {
        t = Input.GetAxis("Turret");
    }

    void FixedUpdate()
    {
        torreta.Rotate(Vector3.up, t * velocidad * Time.fixedDeltaTime);
    }
}
