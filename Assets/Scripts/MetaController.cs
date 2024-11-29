using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaController : MonoBehaviour
{
    public GameObject panelNivelSuperado; // Panel que aparece al ganar el nivel
    public GameObject panelGameOver; // Panel que aparece al perder
    private CombateJugadorController combateJugador;
    private bool nivelTerminado = false; // Indica si el nivel ha terminado
    public GameObject botonSiguiente; // Referencia al bot�n "Siguiente"

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
        if (nivelTerminado) return; // Si el nivel ya termin�, no hacer nada m�s

        if (other.CompareTag("Player"))
        {
            nivelTerminado = true; // Marcar el nivel como terminado
            VerificarProximoNivel();
        }
        else if (other.CompareTag("Enemy"))
        {
            nivelTerminado = true; // Marcar el nivel como terminado
            StartCoroutine(NivelPerdido());
            panelGameOver.SetActive(true);
        }
    }

    private void VerificarProximoNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex; // �ndice de la escena actual
        int siguienteEscena = escenaActual + 1; // �ndice del siguiente nivel

        if (siguienteEscena < SceneManager.sceneCountInBuildSettings)
        {
            // Si hay un siguiente nivel, mostrar el panel de nivel superado y cargarlo
            panelNivelSuperado.SetActive(true);
            StartCoroutine(CargarSiguienteNivel());
        }
 
    }

    private IEnumerator CargarSiguienteNivel()
    {
        yield return new WaitForSeconds(5f); // Esperar unos segundos antes de cambiar de nivel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Cargar siguiente nivel
    }

    private IEnumerator NivelPerdido()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar el nivel actual
    }

    private void OnPlayerDeath(object sender, System.EventArgs e)
    {
        if (nivelTerminado) return; // Si el nivel ya termin�, no hacer nada m�s
        nivelTerminado = true; // Marcar el nivel como terminado
        panelGameOver.SetActive(true); // Activar el panel Game Over
        StartCoroutine(NivelPerdido()); // Iniciar la l�gica de perder el nivel
    }

    private void OnDestroy()
    {
        // Cancelar suscripci�n al evento cuando el objeto se destruya para evitar errores
        if (combateJugador != null)
        {
            combateJugador.MuerteJugador -= OnPlayerDeath;
        }
    }

    // M�todo para cargar el siguiente nivel desde el bot�n
    public void IrAlSiguienteNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex; // Obtener �ndice actual
        int siguienteEscena = escenaActual + 1; // Calcular �ndice del siguiente nivel

        if (siguienteEscena < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteEscena); // Cargar siguiente nivel
        }
        else
        {
            // Mostrar el panel de fin del juego si no hay m�s niveles
            Debug.Log("No hay m�s niveles para cargar. �Has completado el juego!");
        }
    }
}
