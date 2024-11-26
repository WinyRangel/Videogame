using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaController : MonoBehaviour
{
    public GameObject panelNivelSuperado;
    public GameObject panelGameOver;
    private CombateJugadorController combateJugador;
    private bool nivelTerminado = false; // Indica si el nivel ha terminado

    private void Start()
    {
        combateJugador = FindObjectOfType<CombateJugadorController>();
        if (combateJugador != null)
        {
            combateJugador.MuerteJugador += OnPlayerDeath; // Suscribirse al evento de muerte
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (nivelTerminado) return; // Si el nivel ya terminó, no hacer nada más

        if (other.CompareTag("Player"))
        {
            nivelTerminado = true; // Marcar el nivel como terminado
            StartCoroutine(NivelGanado());
            panelNivelSuperado.SetActive(true);
        }
        else if (other.CompareTag("Enemy"))
        {
            nivelTerminado = true; // Marcar el nivel como terminado
            StartCoroutine(NivelPerdido());
            panelGameOver.SetActive(true);
        }
    }

    private IEnumerator NivelGanado()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator NivelPerdido()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnPlayerDeath(object sender, System.EventArgs e)
    {
        if (nivelTerminado) return; // Si el nivel ya terminó, no hacer nada más
        nivelTerminado = true; // Marcar el nivel como terminado
        panelGameOver.SetActive(true); // Activar el panel Game Over
        StartCoroutine(NivelPerdido()); // Iniciar la lógica de perder el nivel
    }

    private void OnDestroy()
    {
        // Cancelar suscripción al evento cuando el objeto se destruya para evitar errores
        if (combateJugador != null)
        {
            combateJugador.MuerteJugador -= OnPlayerDeath;
        }
    }
}
