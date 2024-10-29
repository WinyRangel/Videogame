using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Variables para controlar el movimiento del enemigo
    public float speed =3.0f;  // Velocidad del enemigo
    public float fuerzaSalto = 5.0f; // Fuerza de salto del enemigo
    public LayerMask queEsSuelo; // Capa que representa el suelo
    public Transform controladorSuelo; // Objeto para verificar si está en el suelo
    public Vector3 dimensionesCaja; // Dimensiones de la caja para detectar el suelo

    private Rigidbody2D rb2D;
    private bool enSuelo;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mover al enemigo siempre hacia la derecha
        transform.position += Vector3.right * speed * Time.deltaTime;

        // Verificar si el enemigo está en el suelo
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        // Hacer que el enemigo salte automáticamente si está en el suelo
        if (enSuelo)
        {
            Saltar();
        }
    }

    private void Saltar()
    {
        rb2D = GetComponent<Rigidbody2D>();
        // Restringir la rotación en el eje Z para evitar que gire al colisionar
        rb2D.freezeRotation = true;
        rb2D.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
