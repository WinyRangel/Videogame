using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float velocidad = 5f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Vector para almacenar el movimiento
        Vector3 movimiento = Vector3.zero;

        // Movimiento según las teclas especificadas
        if (Input.GetKey(KeyCode.Y)) // NORTE
        {
            movimiento.y = 1;
            if (animator != null)
                animator.SetTrigger("Norte");
        }

        if (Input.GetKey(KeyCode.K)) // SUR
        {
            movimiento.y = -1;
            if (animator != null)
                animator.SetTrigger("Sur");
        }

        if (Input.GetKey(KeyCode.J)) // ESTE
        {
            movimiento.x = -1;
            if (animator != null)
                animator.SetTrigger("Este");
        }

        if (Input.GetKey(KeyCode.L)) // OESTE
        {
            movimiento.x = 1;
            if (animator != null)
                animator.SetTrigger("Oeste");
        }

        // Aplicar el movimiento
        transform.position += movimiento * velocidad * Time.deltaTime;
    }
}