using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CombateJugadorController : MonoBehaviour
{
    [SerializeField] private float vida;

    [SerializeField] private float maximoVida;

    [SerializeField] private BarraVidaController barraVida;

    public event EventHandler MuerteJugador;
    void Start()
    {
        vida = maximoVida;
        barraVida.InicializarBarraVida(vida);
    }

    public void TomarDa�o(int da�o)
    {
        vida -= da�o;
        barraVida.CambiarVidaActual(vida);
        if (vida <= 0)  // Cambiar la condici�n para incluir 0
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }

    public void Curar(int curacion)
    {
        // Calcular la nueva cantidad de vida, respetando el m�ximo
        vida = Mathf.Min(vida + curacion, maximoVida);

        // Actualizar la barra de vida con la nueva cantidad de vida
        barraVida.CambiarVidaActual(vida);
    /*
     if((vida + curacion) >  maximoVida){
         vida = maximoVida;
     }
     else
     {
         vida += curacion;
     }
     */
}
       


}
