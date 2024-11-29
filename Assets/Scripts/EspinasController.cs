using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinasController : MonoBehaviour
{
    public int da�o;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out VidaJugador vidaJugador))
        {
            vidaJugador.TomarDa�o(da�o);
        }
    }
}
