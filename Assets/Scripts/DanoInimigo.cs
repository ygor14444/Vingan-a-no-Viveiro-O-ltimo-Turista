using UnityEngine;

public class DanoInimigo : MonoBehaviour
{
    public int danoParaDar = 1;
    public float tempoEntreAtaques = 2f; // O tempo de espera que querias (2 segundos)
    private float cronometroAtaque;

    void Update()
    {
        // O cronómetro fica sempre a contar o tempo em segundos
        if (cronometroAtaque > 0)
        {
            cronometroAtaque -= Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D colisao)
    {
        // Se for o Jogador e o cronómetro já chegou a zero...
        if (colisao.gameObject.name == "Jogador" && cronometroAtaque <= 0)
        {
            VidaJogador scriptVida = colisao.gameObject.GetComponent<VidaJogador>();

            if (scriptVida != null)
            {
                scriptVida.LevarDano(danoParaDar);
                
                // Reinicia o cronómetro para 2 segundos, forçando a uva a esperar
                cronometroAtaque = tempoEntreAtaques; 
            }
        }
    }
}