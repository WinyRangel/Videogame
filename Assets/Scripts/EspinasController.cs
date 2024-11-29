using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinasController : MonoBehaviour
{
    public int daño;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out VidaJugador vidaJugador))
        {
            vidaJugador.TomarDaño(daño);
        }
    }
}
