using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class VidaJugador : MonoBehaviour
{
    public int vidaActual;
    public int vidaMaxima;
    public int valorPrueba;
    public UnityEvent<int> cambioVida;
    private void Start()
    {
        vidaActual = vidaMaxima;
        cambioVida.Invoke(vidaActual);
    }

    private void Update()
    {
        
    }

    public void TomarDa�o(int cantidadDa�o)
    {
        int vidaTemporal = vidaActual - cantidadDa�o;

        if (vidaTemporal < 0)
        {
            vidaActual = 0;
        }
        else
        {
            vidaActual = vidaTemporal;
        }
        cambioVida.Invoke(vidaActual);
        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void CurarVida(int cantidadCuracion)
    {
        int vidaTemporal = vidaActual + cantidadCuracion;
        if (vidaTemporal > vidaMaxima)
        {
            vidaActual = vidaMaxima;
        }
        else
        {
            vidaActual = vidaTemporal;
        }
        cambioVida.Invoke(vidaActual);
    }
}