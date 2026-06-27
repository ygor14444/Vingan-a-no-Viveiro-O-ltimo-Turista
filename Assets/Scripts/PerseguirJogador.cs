using UnityEngine;

public class PerseguirJogador : MonoBehaviour
{
    public float velocidade = 3.5f; // Velocidade da uva
    private Transform alvoJogador;

    // --- NOVAS VARIÁVEIS PARA ANIMAÇÃO E MORTE ---
    private Animator anim;
    private bool estaMorto = false;

    void Start()
    {
        // Pega o componente Animator anexado à uva pequena
        anim = GetComponent<Animator>();

        // Procura no jogo inteiro pelo objeto que tem o nome "Jogador"
        GameObject jogadorObjeto = GameObject.Find("Jogador");
        
        if (jogadorObjeto != null)
        {
            alvoJogador = jogadorObjeto.transform;
        }
    }

    void Update()
    {
        // Se a uva já estiver morta, ela não deve continuar perseguindo o jogador!
        if (estaMorto) return;

        // Se o jogador existir na cena, a uva caminha até ele
        if (alvoJogador != null)
        {
            // Calcula a direção em direção ao herói
            Vector2 direcao = (alvoJogador.position - transform.position).normalized;
            
            // Move o inimigo usando o transform de forma simples
            transform.Translate(direcao * velocidade * Time.deltaTime);

            // Código extra opcional: Vira a uva para a esquerda ou direita dependendo de onde o jogador está
            if (direcao.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1); // Olha para a direita
            }
            else if (direcao.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Olha para a esquerda
            }
        }
    }

    // --- NOVA FUNÇÃO: DETETAR O TIRO DO JOGADOR ---
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        // Só morre se já não estiver morta E se o objeto que colidiu tiver a Tag "Bala"
        if (!estaMorto && colisao.CompareTag("Bala"))
        {
            Morrer();

            // Destrói a bala para ela não atravessar e matar outras uvas de uma vez só
            Destroy(colisao.gameObject);
        }
    }

    void Morrer()
    {
        estaMorto = true;

        if (anim != null)
        {
            // Ativa o Trigger "Morrer" que configuramos no Animator
            anim.SetTrigger("Morrer");
        }

        // Desativa o Collider da uva para o jogador conseguir passar por cima do corpo dela
        if (GetComponent<Collider2D>() != null)
        {
            GetComponent<Collider2D>().enabled = false;
        }

        // Destrói o objeto da uva da cena após 1.2 segundos (tempo para ver o sprite sumindo)
        Destroy(gameObject, 1.2f);
    }
}