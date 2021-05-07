using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public AudioClip sonidoExplosion;
    public ParticleSystem prefabExplosion;

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

        GameObject.Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
