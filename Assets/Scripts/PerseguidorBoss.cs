using UnityEngine;

public class PerseguidorBoss : MonoBehaviour
{
    public float velocidade = 1.5f; 
    private Transform alvoJogador;
    
    // --- NOVA VARIÁVEL PARA ANIMAÇÃO ---
    private Animator anim;

    void Start()
    {
        // Pega o Animator anexado ao Boss
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Se ainda não achou o jogador, procura na Hierarchy pelo nome exato
        if (alvoJogador == null)
        {
            GameObject jogador = GameObject.Find("Jogador");
            if (jogador != null)
            {
                alvoJogador = jogador.transform;
            }
        }

        // Se achou, move o Boss na direção dele
        if (alvoJogador != null)
        {
            Vector2 direcao = alvoJogador.position - transform.position;
            transform.Translate(direcao.normalized * velocidade * Time.deltaTime);

            // ENVIA A VELOCIDADE PARA O ANIMATOR (Se está perseguindo, manda a velocidade atual)
            anim.SetFloat("Velocidade", velocidade);

            // [OPCIONAL] Vira o Boss para o lado que está o jogador
            RotacionarBoss(direcao.x);
        }
        else
        {
            // Se não tem jogador (ou o jogador morreu), o Boss fica parado
            anim.SetFloat("Velocidade", 0f);
        }
    }

    // Faz o sprite do Boss olhar para a esquerda ou direita baseado na posição do jogador
    void RotacionarBoss(float direcaoX)
    {
        if (direcaoX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Vira para a esquerda
        }
        else if (direcaoX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);  // Vira para a direita
        }
    }
}