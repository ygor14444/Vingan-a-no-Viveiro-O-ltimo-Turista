using UnityEngine;

public class MovimentoInputManager : MonoBehaviour
{
    public float velocidade = 5f;

    // --- VARIÁVEIS PARA O TIRO ---
    [Header("Configurações do Tiro")]
    public Transform pontoDoTiro; // O objeto vazio no cano da arma
    public GameObject prefabBala;  // O arquivo azul da bala que criaste
    // -----------------------------------

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 direcaoMovimento;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimentação normal
        float moverX = Input.GetAxisRaw("Horizontal");
        float moverY = Input.GetAxisRaw("Vertical");
        direcaoMovimento = new Vector2(moverX, moverY).normalized;
        
        // ENVIA A VELOCIDADE PARA O ANIMATOR
        anim.SetFloat("Velocidade", direcaoMovimento.magnitude);

        // --- ATUALIZAÇÃO: Vira o corpo baseado no MOUSE para não quebrar o tiro ---
        RotacionarPersonagem();

        // --- LÓGICA: FAZER O PONTO DO TIRO APONTAR PARA O RATO ---
        if (pontoDoTiro != null)
        {
            // Pega a posição do rato no mundo do jogo
            Vector3 posicaoRato = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicaoRato.z = 0f; // Garante que estamos em 2D

            // Calcula a direção do PontoDoTiro até ao Rato
            Vector2 direcaoParaORato = (posicaoRato - pontoDoTiro.position).normalized;

            // Transforma essa direção num ângulo em graus
            float angulo = Mathf.Atan2(direcaoParaORato.y, direcaoParaORato.x) * Mathf.Rad2Deg;

            // Aplica a rotação no PontoDoTiro
            pontoDoTiro.rotation = Quaternion.Euler(0, 0, angulo);
        }

        // Detetar o clique do rato para atirar
        if (Input.GetButtonDown("Fire1"))
        {
            Atirar();
        }
    }

    void Atirar()
    {
        if (pontoDoTiro != null && prefabBala != null)
        {
            // Ativa o gatilho da animação de tiro no Animator
            anim.SetTrigger("shoot");

            // A bala nasce com a rotação exata do PontoDoTiro
            Instantiate(prefabBala, pontoDoTiro.position, pontoDoTiro.rotation);
        }
    }

    void FixedUpdate()
    {
        // Executa a movimentação física de forma suave
        rb.MovePosition(rb.position + direcaoMovimento * velocidade * Time.fixedDeltaTime);
    }

 void RotacionarPersonagem()
{
    // 1. Pega a posição do mouse no mundo do jogo
    Vector3 posicaoMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    posicaoMouse.z = 0f; // Mantém em 2D

    // 2. Calcula a direção entre o corpo do jogador e o mouse
    Vector2 direcaoAoMouse = (posicaoMouse - transform.position).normalized;

    // 3. Transforma essa direção em um ângulo de 0 a 360 graus
    float angulo360 = Mathf.Atan2(direcaoAoMouse.y, direcaoAoMouse.x) * Mathf.Rad2Deg;

    // 4. Aplica a rotação no eixo Z do jogador
    transform.rotation = Quaternion.Euler(0, 0, angulo360);
}}