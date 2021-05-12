using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public AudioClip sonidoExplosion;
    public ParticleSystem prefabExplosion;
    public float radioExplosion = 1.0f;
    private Collider[] cols;

    private void Start()
    {
        cols = new Collider[20];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        var managerFx = GameObject.Find("ManagerFxSonido");
        var manager = managerFx.GetComponent<FxSonidoManager>();
        manager.PlaySonido(sonidoExplosion, transform.position);

        var explosion = GameObject.Instantiate(prefabExplosion, transform.position, Quaternion.identity);

        int cant = Physics.OverlapSphereNonAlloc(transform.position, radioExplosion, cols);
        //foreach (var c in cols)
        for (int i=0; i < cant; ++i)
        {
            var c = cols[i];
            //if (c.gameObject == gameObject)
            //    continue;
            Debug.Log($"Exploto {c.gameObject.name}");
            //c.SendMessage("OnDanio", SendMessageOptions.DontRequireReceiver);
            SubBlock sb = c.GetComponent<SubBlock>();
            if (sb != null)
            {
                sb.OnDanio();
            }
        }

        GameObject.Destroy(gameObject);
        //gameObject.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radioExplosion);
    }
}
