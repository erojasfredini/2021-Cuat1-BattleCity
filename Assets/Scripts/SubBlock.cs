using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SubBlock : MonoBehaviour
{
    private Block padre;

    private void OnTriggerEnter(Collider other)
    {
        if (padre.esDestruible && other.CompareTag("Bala"))
        {
            if (padre.vida > 0)
            {
                padre.vida -= 1;
            }

            GameObject.Destroy(gameObject);
        }
    }

    void Start()
    {
        padre = transform.parent.GetComponent<Block>();
        Assert.IsNotNull(padre, "El padre no tiene block!");
    }
}
