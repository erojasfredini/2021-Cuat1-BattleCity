using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject menuJugar;
    public GameObject menuOpciones;
    public void OnJugar()
    {
        Debug.Log("Jugar!");
        SceneManager.LoadScene("Main");
        //SceneManager.LoadScene(1);
    }

    public void OnOpciones()
    {
        Debug.Log("Opciones");
        menuJugar.active = false;
        menuOpciones.active = true;
    }

    public void OnSalir()
    {
        Debug.Log("Salir :(");
        Application.Quit();
    }

    public void OnAtras()
    {
        Debug.Log("Atras");
        menuJugar.active = true;
        menuOpciones.active = false;
    }
}
