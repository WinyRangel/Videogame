using UnityEngine;

public class ZonaMuerteController : MonoBehaviour
{
    public GameObject menuGameOver; // Referencia al panel del Game Over

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            Debug.Log("El jugador ha tocado la zona de muerte. Perdiste.");
            PerderNivel(); // Llamar al método para manejar la derrota
        }
    }

    private void PerderNivel()
    {
        if (menuGameOver != null)
        {
            menuGameOver.SetActive(true); // Activar el panel de Game Over
            //Time.timeScale = 0; // Detener el tiempo para pausar el juego
        }
        else
        {
            Debug.LogError("MenuGameOver no está asignado en el Inspector.");
        }
    }
}
