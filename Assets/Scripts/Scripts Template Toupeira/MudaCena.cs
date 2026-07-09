using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCena : MonoBehaviour
{
    bool jaMudou;

    public void MudaParaJogo()
    {
        SceneManager.LoadScene(1);
    }

    public void MudaParaFim()
    {
        SceneManager.LoadScene(2);
    }

    void Update()
    {
        if (jaMudou)
        {
            return;
        }

        if (ContadorDePonto.Instance != null && ContadorDePonto.Instance.Pontuacao >= 200)
        {
            jaMudou = true;
            MudaParaFim();
        }
    }
    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(0);
    }
    
}
