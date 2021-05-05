using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    public AudioClip sonidoMovimiento;
    public AudioClip sonidoQuieto;
    private AudioSource audioSource;

    /// <summary>
    /// La velocidad lineal
    /// </summary>
    public float velocidadLineal = 1.5f;
    public float velocidadRotacion = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        velocidadMinMax = new Vector2(0.0f, velocidadLineal);
    }

    private Rigidbody rb;
    private float h;
    private float v;

    public Vector2 pitchMinMax = new Vector2(1.0f, 1.4f);
    private Vector2 velocidadMinMax;
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (audioSource != null)
        {
            if (rb.velocity.sqrMagnitude > 0.1f)
            {
                // Poner sonido de movimiento
                if ((audioSource.clip != sonidoMovimiento) || !audioSource.isPlaying)
                {
                    audioSource.clip = sonidoMovimiento;
                    audioSource.Play();
                }

                float pitchCoef = Mathf.InverseLerp(velocidadMinMax.x, velocidadMinMax.y, rb.velocity.magnitude);
                audioSource.pitch = Mathf.Lerp(pitchMinMax.x, pitchMinMax.y, pitchCoef);
            }
            else
            {
                if ((audioSource.clip != sonidoQuieto) || !audioSource.isPlaying)
                {
                    // Poner sonido de estar quieto
                    audioSource.clip = sonidoQuieto;
                    audioSource.Play();
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.angularVelocity = h * transform.up * velocidadRotacion;
        rb.velocity = v * transform.forward * velocidadLineal + Vector3.up * rb.velocity.y;
    }
}
