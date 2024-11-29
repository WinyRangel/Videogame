using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;  // Panel de Game Over
    private VidaJugador vidaJugador;  // Referencia al script VidaJugador

    private void Start()
    {
        // Iniciar Coroutine para esperar la instancia del jugador
        StartCoroutine(EsperarJugador());
    }

    private IEnumerator EsperarJugador()
    {
        // Espera hasta que el jugador sea instanciado
        GameObject jugador = null;
        while (jugador == null)
        {
            jugador = GameObject.FindGameObjectWithTag("Player");
            yield return null; // Espera hasta el siguiente frame
        }

        // Ahora el jugador está disponible, asignamos el componente VidaJugador
        vidaJugador = jugador.GetComponent<VidaJugador>();

        if (vidaJugador != null)
        {
            // Suscríbete al evento de cambio de vida
            vidaJugador.cambioVida.AddListener(VerificarVidaJugador);
        }
        else
        {
            Debug.LogError("El objeto jugador no tiene el componente VidaJugador.");
        }

        // Asegúrate de que el menú de Game Over esté oculto al principio
        menuGameOver.SetActive(false);
    }

    private void VerificarVidaJugador(int vidaActual)
    {
        // Si la vida llega a 0, muestra el menú de Game Over
        if (vidaActual <= 0)
        {
            ActivarMenu();
        }
    }

    private void ActivarMenu()
    {
        menuGameOver.SetActive(true); // Activa el panel de Game Over
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre); // Carga la escena del menú inicial
    }

    public void Salir()
    {
        Application.Quit(); // Sale del juego
    }
}
