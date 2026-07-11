using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Configurações do Movimento")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpVelocity = 10f;
    // Variável para armazenar o valor do movimento do jogador
    private Vector2 movementInput;
    // Referência para o componente Rigidbody2D
    private Rigidbody2D rb;
    // Referência para o script Flip
    private Flip scriptFlip;
    private void Awake()
    {
        // Obtém referências para os componentes Rigidbody2D e Flip
        rb = GetComponent<Rigidbody2D>();
        scriptFlip = GetComponent<Flip>();
    }

    // Chamado pelo evento do Player Input
    public void OnMove(InputAction.CallbackContext context)
    {
        // Lê o valor do movimento do jogador (eixo X e Y) e armazena na variável movementInput
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
        // Mantemos a velocidade Y atual e alteramos apenas a X
        rb.linearVelocity = new Vector2(movementInput.x * moveSpeed, rb.linearVelocity.y);

        // Se o jogador estiver se movendo para a direita e o personagem estiver virado para a esquerda, vira o personagem
        if (movementInput.x > 0 && !scriptFlip.IsFacingRight)
        {
            // Chama o método FlipCharacter() do script Flip para virar o personagem
            scriptFlip.FlipCharacter();
        }
        // Se o jogador estiver se movendo para a esquerda e o personagem estiver virado para a direita, vira o personagem
        else if (movementInput.x < 0 && scriptFlip.IsFacingRight)
        {
            // Chama o método FlipCharacter() do script Flip para virar o personagem
            scriptFlip.FlipCharacter();
        }
    }
}
