using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables para controlar el movimiento del enemigo
    public float speed = 2.0f;   // Velocidad del enemigo
    public float moveDistance = 5.0f;   // Distancia máxima que el enemigo se moverá antes de cambiar de dirección

    private Vector3 startPosition;  // Posición inicial del enemigo
    private bool movingRight = true; // Dirección de movimiento (true = derecha, false = izquierda)

    // Start is called before the first frame update
    void Start()
    {
        // Guardar la posición inicial del enemigo
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Mover al enemigo en función de la dirección actual
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // Verificar si el enemigo ha alcanzado la distancia máxima para cambiar de dirección
        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            movingRight = !movingRight;  // Cambiar de dirección
            startPosition = transform.position;  // Actualizar la nueva posición de referencia
        }
    }
}
