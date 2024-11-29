using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PantallaReglas : MonoBehaviour
{
    // Referencia al Panel de reglas
    [SerializeField] private GameObject panelReglas;

    // Referencia al bot�n de cerrar
    [SerializeField] private Button botonCerrar;

    private void Start()
    {
        // Aseg�rate de que el panel de reglas est� inicialmente desactivado
        panelReglas.SetActive(false);

        // Si el bot�n de cerrar est� asignado, a�adir la funci�n al evento de clic
        if (botonCerrar != null)
        {
            botonCerrar.onClick.AddListener(CerrarReglas);
        }
    }

    // Funci�n para abrir la pantalla de reglas
    public void MostrarReglas()
    {
        panelReglas.SetActive(true);  // Activa el panel de reglas
    }

    // Funci�n para cerrar la pantalla de reglas
    private void CerrarReglas()
    {
        panelReglas.SetActive(false);  // Desactiva el panel de reglas
    }
}
