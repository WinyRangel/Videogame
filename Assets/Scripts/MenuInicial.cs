using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private PantallaReglas pantallaReglas;

    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    // Funci�n para abrir la pantalla de reglas
    public void MostrarReglas()
    {
        if (pantallaReglas != null)
        {
            pantallaReglas.MostrarReglas();
        }
        else
        {
            Debug.LogError("PantallaReglas no est� asignada en el inspector.");
        }
    }

}
