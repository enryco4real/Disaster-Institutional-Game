using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private Animator animator;  // Adicionando referência ao Animator
    private SpriteRenderer spriteRenderer;  // Referência ao SpriteRenderer

    // Gravação de posições
    public static Queue<Vector3> recordedPositions = new Queue<Vector3>();
    public int maxRecordedFrames = 300;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();  // Obtendo o componente Animator
        spriteRenderer = GetComponent<SpriteRenderer>();  // Obtendo o componente SpriteRenderer
    }

    void Update()
    {
        // Movimento
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Verificando se o personagem está se movendo
        animator.SetFloat("Speed", Mathf.Abs(move));  // Definindo a variável "Speed" no Animator (verifique se você tem essa variável no Animator)

        // Se houver movimento, vira o personagem
        if (move < 0 && spriteRenderer.flipX)  // Se move para a direita e o personagem está virado para a esquerda
        {
            spriteRenderer.flipX = false;
        }
        else if (move > 0 && !spriteRenderer.flipX)  // Se move para a esquerda e o personagem está virado para a direita
        {
            spriteRenderer.flipX = true;
        }

        // Pulo
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f) // Verificando se o jogador está no chão (evitar pulo duplo)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");  // Definindo um "trigger" de pulo no Animator (verifique se você tem esse trigger configurado)
        }

        // Grava a posição atual
        recordedPositions.Enqueue(transform.position);

        // Limita o tamanho da fila
        if (recordedPositions.Count > maxRecordedFrames)
        {
            recordedPositions.Dequeue();
        }
    }
}
