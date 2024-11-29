using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PantallaReglas : MonoBehaviour
{
    // Referencia al Panel de reglas
    [SerializeField] private GameObject panelReglas;

    // Referencia al botón de cerrar
    [SerializeField] private Button botonCerrar;

    private void Start()
    {
        // Asegúrate de que el panel de reglas esté inicialmente desactivado
        panelReglas.SetActive(false);

        // Si el botón de cerrar está asignado, añadir la función al evento de clic
        if (botonCerrar != null)
        {
            botonCerrar.onClick.AddListener(CerrarReglas);
        }
    }

    // Función para abrir la pantalla de reglas
    public void MostrarReglas()
    {
        panelReglas.SetActive(true);  // Activa el panel de reglas
    }

    // Función para cerrar la pantalla de reglas
    private void CerrarReglas()
    {
        panelReglas.SetActive(false);  // Desactiva el panel de reglas
    }
}
