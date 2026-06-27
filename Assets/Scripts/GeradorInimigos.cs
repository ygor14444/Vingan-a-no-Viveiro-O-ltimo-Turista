using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject prefabUvaPequena;
    public GameObject prefabBoss; // Arrasta o teu Boss aqui (como Prefab)
    
    public float tempoEntreInimigos = 3f;
    private float cronometro;
    
    public int pontosParaAparecerBoss = 15; // Quantas uvas tens de matar para o Boss vir
    private bool bossJaNasceu = false;

    void Start()
    {
        cronometro = tempoEntreInimigos;
    }

    void Update()
    {
        // Se o Boss já nasceu, o gerador para de criar inimigos pequenos para focares no Boss
        if (bossJaNasceu) return;

        // Verifica se o jogador já atingiu os pontos necessários para o Boss aparecer
        if (GerenciadorPontos.instancia != null && GerenciadorPontos.instancia.textoPontuacao != null)
        {
            // Vamos verificar os pontos. Se o teu Gerenciador tiver uma variável pública de pontos, usamos ela.
            // Para simplificar, se quiseres ativar o Boss por código, podemos fazer o seguinte:
        }

        cronometro -= Time.deltaTime;

        if (cronometro <= 0)
        {
            NascerUva();
            cronometro = tempoEntreInimigos;
        }
    }

    void NascerUva()
    {
        // Cria a uva pequena numa posição aleatória (podes manter a tua lógica atual aqui)
        Instantiate(prefabUvaPequena, transform.position, Quaternion.identity);
    }

    // Função que podes chamar ou adaptar para o Boss nascer!
    public void SpawnarBoss()
    {
        if (!bossJaNasceu && prefabBoss != null)
        {
            Instantiate(prefabBoss, transform.position, Quaternion.identity);
            bossJaNasceu = true;
        }
    }
}