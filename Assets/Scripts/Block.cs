using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool esDestruible = false;
    public uint vidasInicial = 4;

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
    }

    void Update()
    {
    }
}
