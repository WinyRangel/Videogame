using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiController : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private PuntajeController puntaje;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar que el objeto que toca el player es un rollo de sushi
        if (other.CompareTag("Player") && gameObject.CompareTag("Sushi"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            Debug.Log("Sushi tomado");

            // Iniciar la corrutina para destruir el sushi después de un retraso
            StartCoroutine(DestruirConRetraso(0.1f)); // 0.5 segundos de retraso, puedes ajustar el valor
        }
    }
        // Corrutina para destruir el objeto con un retraso
        private IEnumerator DestruirConRetraso(float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(gameObject);
        }

    }
