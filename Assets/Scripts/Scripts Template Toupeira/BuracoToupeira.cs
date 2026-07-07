using UnityEngine;

public class BuracoToupeira : MonoBehaviour
{
    // Variável que define pontos por clique na toupeira
    public int PontosPorToupeira;

    // Variável que define velocidade que a toupeira sai e volta da toca
    public float VelocidadeToupeira = 2;

    // Referencia do Transform da toupeira
    public RectTransform Toupeira;


    // Variável privada para definir se Toupeira está saindo da toca
    bool MostrandoToupeira = false;

    // Variável privada para definir se Toupeira está entrnado na toca
    bool EscondendoToupeira = false;

    // Variável privada para movimentação da Toupeira
    float valorFinalY = 0;



    // É chamado 1 vez por frame
    void Update()
    {
        // Checa se a variável Mostrando toupera é verdadeira para iniciar movimentação de mostrar Toupeira
        if (MostrandoToupeira)
        {
            // Checa se a posição Y da toupeira ainda não alcançou o limite final
            if (Toupeira.anchoredPosition.y < -20)
            {
                // Define valor da variável como soma da VelocidadeToupeira e posição Y atual da Toupeira
                valorFinalY = Toupeira.anchoredPosition.y + VelocidadeToupeira;

                // Checa se a posição Y final da será maior que o limite...
                if (valorFinalY > -20)
                {
                    // Ajusta valor da variável para o limite
                    valorFinalY = -20;
                }

                // Define posição Y da Toupeira igual ao valor da variável valorFinalY
                Toupeira.anchoredPosition = new Vector2(Toupeira.anchoredPosition.x, valorFinalY);
            }
        }


        // Checa se a variável Escondendo toupera é verdadeira para iniciar movimentação de esconder Toupeira
        if (EscondendoToupeira)
        {
            // Checa se a posição Y da toupeira ainda não alcançou o limite final
            if (Toupeira.anchoredPosition.y > -80)
            {
                // Define valor da variável como subtração da VelocidadeToupeira e posição Y atual da Toupeira
                valorFinalY = Toupeira.anchoredPosition.y - VelocidadeToupeira;

                // Checa se a posição Y final da toupeira é menor que o limite...
                if (valorFinalY < -80)
                {
                    // Ajusta valor da variável para o limite
                    valorFinalY = -80;
                }

                // Define posição Y da Toupeira igual ao valor da variável valorFinalY
                Toupeira.anchoredPosition = new Vector2(Toupeira.anchoredPosition.x, valorFinalY);
            }
        }
    }

    // Função pública para iniciar movimentação de Mostrar Toupeira
    public void MostrarToupeira()
    {
        MostrandoToupeira = true;
        EscondendoToupeira = false;
    }

    // Função pública para iniciar movimentação de Esconder Toupeira
    public void EsconderToupeira()
    {
        MostrandoToupeira = false;
        EscondendoToupeira = true;
    }


    // Função pública eventos ao clicar na Toupeira
    public void ClicarNaToupeira()
    {
        // Aviso no console
        Debug.Log("ClicarNaToupeira");

        // Chamar função de EsconderToupeira()
        EsconderToupeira();

        // Chamar função de AdicionarPontos do ContadorDePontos da cena
        ContadorDePonto.Instance.AdicionarPontos(PontosPorToupeira);
    }
}
