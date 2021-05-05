using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxSonidoManager : MonoBehaviour
{
    public GameObject prefabSonido;
    private AudioSource[] sonidos = new AudioSource[100];

    void Start()
    {
        for (int i=0; i < sonidos.Length; ++i)
        {
            sonidos[i] = GameObject.Instantiate(prefabSonido).GetComponent<AudioSource>();
            sonidos[i].transform.parent = transform;
        }
    }

    public void PlaySonido(AudioClip clip, Vector3 posicion)
    {
        for (int i = 0; i < sonidos.Length; ++i)
        {
            if (!sonidos[i].isPlaying)
            {
                sonidos[i].transform.position = posicion;
                sonidos[i].PlayOneShot(clip);
                break;
            }
        }
    }
}
