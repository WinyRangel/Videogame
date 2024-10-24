using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rbD2;

    [Header("Movimiento")]
    private float movimientoHorizontal = 0f;
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float suavidadDeMovimiento;

    private Vector3 velocidad = Vector3.zero;

    private bool mirandoDerecha = true; // Inicialmente mirando a la derecha

    [Header("Salto")]

    [SerializeField] private float fuerzaSalto;
    [SerializeField] private LayerMask queEsSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;

    private bool salto = false;

    [Header("Animación")]

    private Animator animator;

    void Start()
    {
        rbD2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // Capturar movimiento horizontal
        movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadDeMovimiento;
        animator.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
        // Detectar salto
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            salto = true;
        }
    }

    private void FixedUpdate()
    {
        // Verificar si el personaje está en el suelo
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);

        // Mover personaje
        Mover(movimientoHorizontal * Time.fixedDeltaTime, salto);

        salto = false;
    }

    private void Mover(float mover, bool saltar)
    {
        // Definir la velocidad objetivo
        Vector3 velocidadObjetivo = new Vector2(mover, rbD2.velocity.y);
        rbD2.velocity = Vector3.SmoothDamp(rbD2.velocity, velocidadObjetivo, ref velocidad, suavidadDeMovimiento);

        // Girar el personaje si es necesario
        if (mover > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (mover < 0 && mirandoDerecha)
        {
            Girar();
        }

        // Ejecutar salto si está en el suelo y se presionó el botón de salto
        if (enSuelo && saltar)
        {
            rbD2.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse); // Usar ForceMode2D.Impulse para un salto más inmediato
        }
    }

    private void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;

        escala.x *= -1;

        transform.localScale = escala;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
