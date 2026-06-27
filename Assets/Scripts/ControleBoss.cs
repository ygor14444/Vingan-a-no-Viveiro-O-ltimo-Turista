using UnityEngine;

public class ControleBoss : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D meuCollider;
    private bool bossAtivo = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        meuCollider = GetComponent<Collider2D>();

        // Começa o jogo invisível e sem colisão para não andar nem atacar
        EsconderBoss();
    }

    void Update()
    {
        // Se o Boss ainda não foi chamado pelo Gerenciador, ele não faz nada
        if (!bossAtivo)
        {
            // Garante que ele fica parado na posição inicial dele
            return; 
        }
    }

    void EsconderBoss()
    {
        if (spriteRenderer != null) spriteRenderer.enabled = false;
        if (meuCollider != null) meuCollider.enabled = false;
        
        // Se o teu Boss usa RigidBody2D, paramos o movimento dele
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.simulated = false;
    }

    // Função que o Gerenciador vai chamar quando o jogador atingir os pontos!
    public void DespertarBoss()
    {
        bossAtivo = true;
        
        if (spriteRenderer != null) spriteRenderer.enabled = true;
        if (meuCollider != null) meuCollider.enabled = true;
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.simulated = true;

        Debug.Log("O BOSS DESPERTOU!");
    }
}