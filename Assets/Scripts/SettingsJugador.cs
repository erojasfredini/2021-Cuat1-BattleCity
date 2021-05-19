using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsJugador : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public string nombreJugador;
}
