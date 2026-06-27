using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ControladorIntro : MonoBehaviour
{
    private VideoPlayer meuVideoPlayer;

    void Start()
    {
        // Pega o componente de vídeo que está no mesmo objeto
        meuVideoPlayer = GetComponent<VideoPlayer>();
        
        // Diz ao Unity para chamar a função "MudarParaO_Jogo" assim que o vídeo terminar
        meuVideoPlayer.loopPointReached += MudarParaO_Jogo;
    }

    void Update()
    {
        // BÓNUS: Se o jogador carregar na barra de Espaço, pula a intro e vai direto para o jogo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Principal");
        }
    }

    void MudarParaO_Jogo(VideoPlayer source)
    {
        // Carrega a tua cena de gameplay
        SceneManager.LoadScene("Principal");
    }
}