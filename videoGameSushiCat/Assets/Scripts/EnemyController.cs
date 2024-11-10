using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables para controlar el movimiento del enemigo
    public float speed = 2.0f;   // Velocidad del enemigo
    public float moveDistance = 5.0f;   // Distancia m�xima que el enemigo se mover� antes de cambiar de direcci�n

    private Vector3 startPosition;  // Posici�n inicial del enemigo
    private bool movingRight = true; // Direcci�n de movimiento (true = derecha, false = izquierda)

    // Start is called before the first frame update
    void Start()
    {
        // Guardar la posici�n inicial del enemigo
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Mover al enemigo en funci�n de la direcci�n actual
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        // Verificar si el enemigo ha alcanzado la distancia m�xima para cambiar de direcci�n
        if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
        {
            movingRight = !movingRight;  // Cambiar de direcci�n
            startPosition = transform.position;  // Actualizar la nueva posici�n de referencia
        }
    }
}
