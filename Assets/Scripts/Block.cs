using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public enum TipoBloque
    {
        Destruible,
        Indestructible,
        Atravesable
    }
    public TipoBloque tipoBloque = TipoBloque.Destruible;
    public uint vidasInicial = 4;

    public bool esAtravesable
    {
        get
        {
            return tipoBloque == TipoBloque.Atravesable;
        }
    }

    public bool esDestruible
    {
        get
        {
            return tipoBloque == TipoBloque.Destruible;
        }
    }

    public bool esIndestructible
    {
        get
        {
            return tipoBloque == TipoBloque.Indestructible;
        }
    }

    private uint _vida;
    public uint vida
    {
        get
        {
            return _vida;
        }
        set
        {
            _vida = value;
            if (_vida == 0)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        _vida = vidasInicial;

        if (esAtravesable)
        {
            foreach (Collider c in transform.GetComponentsInChildren<Collider>())
            {
                c.enabled = false;
            }
        }
    }

    void Update()
    {
    }
}
