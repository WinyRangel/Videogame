using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton para acceder a esta instancia desde otras partes del proyecto
    public static GameManager Instance;

    // Lista de personajes (aseg�rate de que "Personajes" sea una clase v�lida)
    public List<Personajes> personajes;

    // M�todo Awake para implementar el patr�n Singleton
    private void Awake()
    {
        // Verifica si ya existe una instancia de GameManager
        if (GameManager.Instance == null)
        {
            // Si no existe, esta instancia se convierte en la principal
            GameManager.Instance = this;
            // Evita que este objeto se destruya al cambiar de escena
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruye este objeto para evitar duplicados
            Destroy(gameObject);
        }
    }

    // Propiedad para obtener el personaje activo
    public Personajes JugadorActivo
    {
        get
        {
            // Obtiene el �ndice del jugador desde PlayerPrefs
            int indexJugador = PlayerPrefs.GetInt("JugadorIndex", 0);

            // Verifica si el �ndice est� dentro del rango
            if (indexJugador >= 0 && indexJugador < personajes.Count)
            {
                return personajes[indexJugador];
            }

            // Si no hay un jugador v�lido, devuelve null
            Debug.LogWarning("El �ndice del jugador est� fuera de rango.");
            return null;
        }
    }
}
