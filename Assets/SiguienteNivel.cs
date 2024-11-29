using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para manejar las escenas

public class SiguienteNivel : MonoBehaviour
{
    // M�todo que ser� llamado por el bot�n
    public void CargarSiguienteNivel()
    {
        // Obtiene el �ndice de la escena actual
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;

        // Carga la siguiente escena, si existe
        if (indiceEscenaActual + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(indiceEscenaActual + 1);
        }
        else
        {
            Debug.Log("No hay m�s niveles disponibles.");
        }
    }
}
