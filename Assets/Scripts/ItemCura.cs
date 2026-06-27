using UnityEngine;

public class ItemCura : MonoBehaviour
{
    public int quantidadeCura = 1; // Quanto de vida ele recupera

    void OnTriggerEnter2D(Collider2D colisao)
    {
        // Verifica se quem pisou no item foi o Jogador
        if (colisao.gameObject.name == "Jogador")
        {
            // Tenta pegar o script de vida do jogador
            VidaJogador scriptVida = colisao.gameObject.GetComponent<VidaJogador>();

            if (scriptVida != null)
            {
                // Chama uma função para curar (vamos criá-la no próximo passo)
                scriptVida.Curar(quantidadeCura);
                
                // Destrói o coração da tela após ser recolhido
                Destroy(gameObject);
            }
        }
    }
}