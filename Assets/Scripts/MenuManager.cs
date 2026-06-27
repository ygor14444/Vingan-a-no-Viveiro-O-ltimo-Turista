using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para trocar de cenas
using UnityEngine.UI; // Necessário para mexer com os painéis e botões

public class MenuManager : MonoBehaviour
{
    [Header("Painéis do Menu")]
    public GameObject painelPrincipal;
    public GameObject painelConfiguracoes; // Esta é a tua Janela_Configuracoes pop-up
    public GameObject painelCreditos;

    void Start()
    {
        // Garante que o jogo começa com tudo fechado e apenas o menu principal ativo
        VoltarAoMenu(); 
    }

    // --- FUNÇÕES DOS BOTÕES PRINCIPAIS ---

    public void IniciarJogo()
    {
        // Carrega a cena da Intro (certifica-te que o nome da cena na Build Settings é exatamente "Intro")
        SceneManager.LoadScene("Intro"); 
    }

    public void AbrirConfiguracoes()
    {
        // Apenas liga a janela pop-up por cima de tudo, sem desligar o painel principal atrás
        painelConfiguracoes.SetActive(true);
    }

    public void AbrirCreditos()
    {
        // Como os créditos usam a tela toda, desligamos o menu principal
        painelPrincipal.SetActive(false);
        painelCreditos.SetActive(true);
    }

    public void VoltarAoMenu()
    {
        // Função geral para fechar os pop-ups/telas e garantir que o menu principal está visível
        painelPrincipal.SetActive(true);
        painelConfiguracoes.SetActive(false);
        painelCreditos.SetActive(false);
    }

    public void SairDoJogo()
    {
        Debug.Log("O jogo fechou!"); // Só aparece no Unity Editor para testar
        Application.Quit(); // Fecha o jogo de verdade quando for um executável (.exe)
    }

    // --- FUNÇÕES DE CONFIGURAÇÃO ---

    public void AlterarVolume(float valor)
    {
        // O AudioListener controla o volume global do jogo (vai de 0.0 a 1.0)
        AudioListener.volume = valor;
    }

    public void DefinirTelaCheia(bool isFullscreen)
    {
        // Alterna entre modo janela e tela cheia
        Screen.fullScreen = isFullscreen;
    }
}