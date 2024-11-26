using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoyaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("Jugo"))
        {
            other.GetComponent<CombateJugadorController>().Curar(30);
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
