using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorazonesUI : MonoBehaviour
{
    public List<Image> listaCorazones = new List<Image>();
    public GameObject corazonPrefab;

    public Sprite corazonLleno;
    public Sprite corazonVacio;

    private VidaJugador vidaJugador;
    private int indexActual = 0;

    private void Start()
    {
        // Intenta encontrar al jugador dinámicamente al inicio del juego
        StartCoroutine(EsperarJugador());
    }

    private System.Collections.IEnumerator EsperarJugador()
    {
        // Espera hasta que el jugador sea instanciado
        while (GameObject.FindGameObjectWithTag("Player") == null)
        {
            yield return null; // Espera un frame
        }

        // Asigna el VidaJugador del jugador instanciado
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        vidaJugador = jugador.GetComponent<VidaJugador>();

        if (vidaJugador != null)
        {
            vidaJugador.cambioVida.AddListener(CambiarCorazones);
            CrearCorazones(vidaJugador.vidaMaxima); // Crea los corazones basados en la vida máxima
        }
        else
        {
            Debug.LogError("El jugador instanciado no tiene un componente VidaJugador.");
        }
    }

    private void CambiarCorazones(int vidaActual)
    {
        CambiarVida(vidaActual);
    }

    private void CrearCorazones(int cantidadMaximaVida)
    {
        for (int i = 0; i < cantidadMaximaVida; i++)
        {
            GameObject corazon = Instantiate(corazonPrefab, transform);
            Image imagenCorazon = corazon.GetComponent<Image>();

            if (imagenCorazon != null)
            {
                listaCorazones.Add(imagenCorazon);
                imagenCorazon.sprite = corazonLleno;
            }
        }

        indexActual = cantidadMaximaVida;
    }

    private void CambiarVida(int vidaActual)
    {
        if (vidaActual < indexActual)
        {
            QuitarCorazones(vidaActual);
        }
        else if (vidaActual > indexActual)
        {
            AgregarCorazones(vidaActual);
        }
    }

    private void QuitarCorazones(int vidaActual)
    {
        for (int i = indexActual - 1; i >= vidaActual; i--)
        {
            listaCorazones[i].sprite = corazonVacio;
        }

        indexActual = vidaActual;
    }

    private void AgregarCorazones(int vidaActual)
    {
        for (int i = indexActual; i < vidaActual; i++)
        {
            listaCorazones[i].sprite = corazonLleno;
        }

        indexActual = vidaActual;
    }
}
