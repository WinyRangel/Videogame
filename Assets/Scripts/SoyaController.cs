using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoyaController : MonoBehaviour
{
    public int curacion;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out VidaJugador vidaJugador))
        {
            // Cura al jugador
            vidaJugador.CurarVida(curacion);

            // Destruye este objeto con un retraso de 0.1 segundos
            Destroy(gameObject, 0.1f);
        }
    }
}
