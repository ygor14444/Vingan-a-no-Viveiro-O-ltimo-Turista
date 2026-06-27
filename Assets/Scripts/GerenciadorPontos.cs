using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Obrigatório para reiniciar a fase!

public class GerenciadorPontos : MonoBehaviour
{
    public static GerenciadorPontos instancia;
    
    [Header("Componentes de Texto")]
    public TextMeshProUGUI textoPontuacao;
    public TextMeshProUGUI textoVida; 

    [Header("Tela de Game Over")]
    public GameObject painelGameOver; 
    
    [Header("Configuração do Boss")]
    public GameObject objetoBoss; // Arrasta o teu Boss da Hierarchy para aqui!
    public int pontosParaO_Boss = 15; // Quantas uvas precisas de matar para o Boss aparecer

    private int pontosAtuais = 0;

    void Awake()
    {
        if (instancia == null) 
        {
            instancia = this;
        }
    }

    void Start()
    {
        AtualizarTextoPontos();
        // Começa a exibir a vida cheia (10) ao iniciar o jogo
        AtualizarTextoVida(10, 10); 
        
        // Garante que a tela de Game Over começa ESCONDIDA
        if (painelGameOver != null) 
        {
            painelGameOver.SetActive(false);
        }
    }

    public void AdicionarPonto()
    {
        pontosAtuais++;
        AtualizarTextoPontos();

        // VERIFICAÇÃO DO BOSS: Se atingiu os pontos, manda o Boss despertar!
        if (pontosAtuais >= pontosParaO_Boss && objetoBoss != null)
        {
            ControleBoss scriptBoss = objetoBoss.GetComponent<ControleBoss>();
            if (scriptBoss != null)
            {
                scriptBoss.DespertarBoss();
            }
        }
    }

    void AtualizarTextoPontos()
    {
        if (textoPontuacao != null)
        {
            textoPontuacao.text = "Uvas Esmagadas: " + pontosAtuais;
        }
    }

    // Função que o script do jogador chama para atualizar os números no ecrã
    public void AtualizarTextoVida(int vidaAtual, int vidaMaxima)
    {
        if (textoVida != null)
        {
            textoVida.text = "Vida: " + vidaAtual + " / " + vidaMaxima;
        }
    }

    // Função ativa quando o jogador morre
    public void AtivarGameOver()
    {
        if (painelGameOver != null)
        {
            painelGameOver.SetActive(true);
        }
    }

    // Função que o botão de Recomeçar vai chamar
    public void ReiniciarJogo()
    {
        // Recarrega a cena atual do zero
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}