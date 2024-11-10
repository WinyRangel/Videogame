using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugadorController : MonoBehaviour
{
    [SerializeField] int vida;

    [SerializeField] int maximoVida;
    void Start()
    {
        vida = maximoVida;   
    }
    
    public void TomarDa�o(int da�o)
    {
        vida -= da�o;
        if(vida < 0)
        {
            Destroy(gameObject);
        }
    }

    public void Curar(int curacion)
    {
        if((vida + curacion) >  maximoVida){
            vida = maximoVida;
        }
        else
        {
            vida += curacion;
        }
    }


}
