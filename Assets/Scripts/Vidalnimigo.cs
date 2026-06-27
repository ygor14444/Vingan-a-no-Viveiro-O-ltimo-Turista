using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    public int vidaMaxima = 3;
    private int vidaAtual;

    [Header("Configuração de Drop")]
    public GameObject prefabCoracao; // Arrasta o prefab do coração para aqui
    [Range(0f, 1f)] public float chanceDeDrop = 0.3f; // 0.3 = 30% de hipótese

    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    public void LevarDano(int quantidade)
    {
        vidaAtual -= quantidade;
        if (vidaAtual <= 0) Morrer();
    }

    void Morrer()
    {
        if (GerenciadorPontos.instancia != null)
        {
            GerenciadorPontos.instancia.AdicionarPonto();
        }

        // Sistema de Sorteio para o Drop
        if (Random.value <= chanceDeDrop && prefabCoracao != null)
        {
            // Nasce o coração exatamente na posição onde a uva morreu
            Instantiate(prefabCoracao, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}