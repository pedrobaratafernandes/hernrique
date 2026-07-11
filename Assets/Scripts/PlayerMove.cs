using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpVelocity = 10f;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    private bool facingRight = true; // Variável para controlar o estado
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Chamado pelo evento do Player Input
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // context.started garante que o pulo só acontece no clique inicial
        if (context.started)
        {
            // Mantemos a velocidade X atual e alteramos apenas a Y
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
        }
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, rb.linearVelocity.y);

        // Lógica de Flip
        if (movementInput.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (movementInput.x < 0 && facingRight)
        {
            Flip();
        }
    }
    //rotacao por scale -1 no X nao recomendado
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1; // Inverte o eixo X
        transform.localScale = scaler;
    }

    //por rotacao 180 graus por y    private void Flip()
    // {
    //     facingRight = !facingRight;

    //     // Rotaciona 180 graus no eixo Y
    //     transform.Rotate(0f, 180f, 0f);
    // }
}
