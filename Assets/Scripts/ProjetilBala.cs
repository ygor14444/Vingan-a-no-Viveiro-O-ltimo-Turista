using UnityEngine;

public class ProjetilBala : MonoBehaviour
{
    public float velocidade = 15f;
    public int danoDaBala = 1;

    void Start()
    {
        // Move a bala na direção do tiro
        GetComponent<Rigidbody2D>().linearVelocity = transform.right * velocidade;
        Destroy(gameObject, 3f); 
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        // TEXTO DE TESTE: Mostra no Console em que a bala encostou
        Debug.Log("A bala bateu em: " + colisao.gameObject.name + " | Tag: " + colisao.gameObject.tag);

        // Se a Tag do objeto for "Inimigo" (Uva pequena ou Boss)
        if (colisao.gameObject.CompareTag("Inimigo"))
        {
            // Pega o script de vida do inimigo
            VidaInimigo vidaInimigo = colisao.gameObject.GetComponent<VidaInimigo>();

            if (vidaInimigo != null)
            {
                vidaInimigo.LevarDano(danoDaBala);
            }

            // Destrói a bala
            Destroy(gameObject); 
        }
    }
}