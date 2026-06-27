using UnityEngine;
using System.Collections; // Obrigatório para usar Corotinas (IEnumerator)

public class VidaJogador : MonoBehaviour
{
    public int vidaMaxima = 10;
    private int vidaAtual;

    private SpriteRenderer spriteRenderer;
    public Color corDano = Color.red; // Cor que ele vai piscar
    private Color corOriginal;
    public float tempoPiscar = 0.15f; // Quanto tempo ele fica vermelho

    void Start()
    {
        vidaAtual = vidaMaxima;
        
        // Pega o componente de imagem do jogador automaticamente
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            corOriginal = spriteRenderer.color;
        }

        // Atualiza a interface logo no início do jogo
        if (GerenciadorPontos.instancia != null)
        {
            GerenciadorPontos.instancia.AtualizarTextoVida(vidaAtual, vidaMaxima);
        }
    }

    public void LevarDano(int quantidade)
    {
        vidaAtual -= quantidade;
        Debug.Log("Jogador levou dano! Vida restante: " + vidaAtual);

        // Atualiza a interface ao levar dano
        if (GerenciadorPontos.instancia != null)
        {
            GerenciadorPontos.instancia.AtualizarTextoVida(vidaAtual, vidaMaxima);
        }

        // SE O JOGADOR AINDA ESTIVER VIVO, PISCA EM VERMELHO!
        if (vidaAtual > 0)
        {
            StartCoroutine(EfeitoPiscar());
        }
        else
        {
            Morrer();
        }
    }

    // Função mágica que faz o piscar acontecer com tempo de espera
    IEnumerator EfeitoPiscar()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = corDano; // Fica vermelho
            yield return new WaitForSeconds(tempoPiscar); // Espera o tempo definido
            spriteRenderer.color = corOriginal; // Volta ao normal
        }
    }

    public void Curar(int quantidade)
    {
        vidaAtual += quantidade; // Corrigido de 'quantity' para 'quantidade'
        if (vidaAtual > vidaMaxima) vidaAtual = vidaMaxima;

        Debug.Log("Jogador curou! Vida atual: " + vidaAtual);

        if (GerenciadorPontos.instancia != null)
        {
            GerenciadorPontos.instancia.AtualizarTextoVida(vidaAtual, vidaMaxima);
        }
    }

    void Morrer()
    {
        Debug.Log("O Jogador Morreu! Game Over!");
        
        if (GerenciadorPontos.instancia != null)
        {
            GerenciadorPontos.instancia.AtivarGameOver();
        }

        gameObject.SetActive(false); 
    }
}